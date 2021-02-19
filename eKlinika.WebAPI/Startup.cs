using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eKlinika.WebAPI.Database;
using eKlinika.WebAPI.Filters;
using eKlinika.WebAPI.Security;
using eKlinika.WebAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace eKlinika.WebAPI
{
    public class BasicAuthDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            var securityRequirements = new Dictionary<string, IEnumerable<string>>()
        {
            { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
        };

            swaggerDoc.Security = new[] { securityRequirements };
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("eKlinikaConnString");
            //var connection = Configuration.GetConnectionString("eKlinikaDirectConnection");
            services.AddDbContext<eKlinikaContext>(options => options.UseSqlServer(connection));

            services.AddMvc(x => x.Filters.Add<ErrorFilter>()).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "eKlinika API", Version = "v1" });
                c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
                c.DocumentFilter<BasicAuthDocumentFilter>();
            });

            services.AddAuthentication("BasicAuthentication")
              .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IPregledService, PregledService>();
            services.AddScoped<IUputnicaService, UputnicaService>();
            services.AddScoped<IUplateService, UplateService>();
            services.AddScoped<ILijekService, LijekService>();
            services.AddScoped<IApotekaRacunService, ApotekaRacunService>();
            services.AddScoped<IReceptService, ReceptService>();
            services.AddScoped<IRacunStavkaService, RacunStavkaService>();
            services.AddScoped<INarudzbaService, NarudzbaService>();
            services.AddScoped<INarudzbaStavkaService, NarudzbaStavkaService>();
            services.AddScoped<IRecommenderService, RecommenderService>();


            services.AddScoped<IService<Model.Uloge, object>, BaseService<Model.Uloge, object, Uloge>>();
            services.AddScoped<IService<Model.KrvnaGrupa, object>, BaseService<Model.KrvnaGrupa, object, KrvnaGrupa>>();
            services.AddScoped<IService<Model.VrstaPretrage, object>, BaseService<Model.VrstaPretrage, object, VrstaPretrage>>();
            services.AddScoped<IService<Model.Proizvodjac, object>, BaseService<Model.Proizvodjac, object, Proizvodjac>>();
            services.AddScoped<IService<Model.Dobavljac, object>, BaseService<Model.Dobavljac, object, Dobavljac>>();

            services.AddCors(allowsites => {
                allowsites.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
            StripeConfiguration.ApiKey = "sk_test_51INB7pFoCnvSBaJrXTHULZKslthd4h0NYxgVsDneyFEbxLZBjwzhNTU2l53P8QZFH9ikGd4l7tmOXEPviWESRnP500XmN6G9zd";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //app.UseHsts();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eKlinika API V1");
            });

            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseCors(options => options.AllowAnyOrigin());

            CreateUserRoles(services);
        }

        private void CreateUserRoles(IServiceProvider serviceProvider)
        {
            var UserManager = serviceProvider.GetRequiredService<IKorisniciService>();
            var db = serviceProvider.GetRequiredService<eKlinikaContext>();

            List<string> roles = new List<string> { "Administrator", "Apotekar", "Doktor", "MedicinskaSestra", "Referent", "Pacijent" };
            foreach (var naziv in roles)
            {
                if (db.Uloge.Where(x => x.Naziv == naziv).Any())
                    continue;

                db.Uloge.Add(new Uloge { Naziv = naziv });
            }

            db.SaveChanges();

            int AdminUlogaId = db.Uloge.Where(x => x.Naziv == "Administrator").Select(x => x.Id).FirstOrDefault();

            Database.Korisnici k = new Korisnici
            {
                JMBG = "1234567890123",
                Ime = "Emina",
                Prezime = "Custovic",
                Spol = "F",
                KorisniciUloge = new List<Database.KorisniciUloge>
                {
                    new KorisniciUloge { UlogaId = AdminUlogaId }
                },
                Osoblje = new Osoblje
                {
                    TrajanjeUgovora = "Stalno",
                    Jezici = "en",
                }
            };
            k.UserName = "admin";
            k.Email = "admin@eKlinika.ba";
            string password = "test";
            k.LozinkaSalt = KorisniciService.GenerateSalt();
            k.LozinkaHash = KorisniciService.GenerateHash(k.LozinkaSalt, password);

            if (UserManager.GetByEmail(k.Email) == null)
            {
                db.Korisnici.Add(k);
                db.SaveChanges();
            }
        }
    }
}

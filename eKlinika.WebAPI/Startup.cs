using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eKlinika.WebAPI.Database;
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
            var connection = @"Server=.;Database=eKlinika;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<eKlinikaContext>(options => options.UseSqlServer(connection));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            services.AddScoped<IService<Model.Uloge, object>, BaseService<Model.Uloge, object, Uloge>>();
            services.AddScoped<IService<Model.KrvnaGrupa, object>, BaseService<Model.KrvnaGrupa, object, KrvnaGrupa>>();
            services.AddScoped<IService<Model.VrstaPretrage, object>, BaseService<Model.VrstaPretrage, object, VrstaPretrage>>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider services)
        {
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

            CreateUserRoles(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var UserManager = serviceProvider.GetRequiredService<IKorisniciService>();
            var db = serviceProvider.GetRequiredService<eKlinikaContext>();

            List<string> roles = new List<string> { "Administrator", "Apotekar", "Doktor", "MedicinskaSestra", "Referent", "Pacijent" };
            foreach (var naziv in roles)
            {
                if (db.Uloge.Where(x => x.Naziv == naziv).Any())
                    continue;

                Uloge uloga = new Uloge
                {
                    Naziv = naziv
                };
                db.Uloge.Add(uloga);
            }

            db.SaveChanges();

            int AdminUlogaId = db.Uloge.Where(x => x.Naziv == "Administrator").Select(x => x.Id).FirstOrDefault();
            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management

            Database.Korisnici k = new Korisnici
            {
                JMBG = "1234567890123",
                Ime = "Emina",
                Prezime = "Custovic",
                Spol = "F"
            };
            k.UserName = k.Ime + "." + k.Prezime;
            k.Email = k.UserName + "@eKlinika.ba";
            string password = "123";

            Model.Korisnici existingUser = UserManager.GetByEmail(k.Email);
            if(existingUser == null)
            {
                k.LozinkaSalt = KorisniciService.GenerateSalt();
                k.LozinkaHash = KorisniciService.GenerateHash(k.LozinkaSalt, password);

                db.Korisnici.Add(k);

                Database.KorisniciUloge korisniciUloge = new Database.KorisniciUloge();
                korisniciUloge.KorisnikId = k.Id;
                korisniciUloge.UlogaId = AdminUlogaId;
                db.KorisniciUloge.Add(korisniciUloge);

                db.SaveChanges();
                
                Osoblje osoblje = new Osoblje
                {
                    Id = k.Id,
                    TrajanjeUgovora = "Stalno",
                    Jezici = "en",
                };

                db.Add(osoblje);
                db.SaveChanges();
            }
        }
    }
}

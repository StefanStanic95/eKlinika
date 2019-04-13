using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eKlinika.WebAPI.Database;
using eKlinika.WebAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace eKlinika.WebAPI
{
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

            //and this: add identity and create the db
            services.AddIdentityCore<Korisnici>(options => { });
            new IdentityBuilder(typeof(Korisnici), typeof(IdentityRole), services)
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddSignInManager<SignInManager<Korisnici>>()
                .AddEntityFrameworkStores<eKlinikaContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "eKlinika API", Version = "v1" });
            });


            services.AddScoped<IKorisniciService, KorisniciService>();

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
                app.UseHsts();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eKlinika API V1");
            });

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();

            CreateUserRoles(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<Korisnici>>();
            var db = serviceProvider.GetRequiredService<eKlinikaContext>();

            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
            }
            //Adding Apotekar Role
            roleCheck = await RoleManager.RoleExistsAsync("Apotekar");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Apotekar"));
            }
            //Adding Doktor Role
            roleCheck = await RoleManager.RoleExistsAsync("Doktor");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Doktor"));
            }
            //Adding MedicinskaSestra Role
            roleCheck = await RoleManager.RoleExistsAsync("MedicinskaSestra");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("MedicinskaSestra"));
            }
            //Adding Referent Role
            roleCheck = await RoleManager.RoleExistsAsync("Referent");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Referent"));
            }
            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management

            Korisnici k = new Korisnici
            {
                JMBG = "1234567890123",
                Ime = "Emina",
                Prezime = "Custovic",
                Spol = "F"
            };
            string password = "myP@ssW0r@d123";

            k.UserName = k.Ime + "." + k.Prezime;
            k.Email = k.UserName + "@eKlinika.ba";

            Korisnici user = await UserManager.FindByEmailAsync(k.Email);
            if(user != null)
            {
                await UserManager.AddToRoleAsync(user, "Admin");
            }
            else
            {
                IdentityResult chkUser = await UserManager.CreateAsync(k, password);

                await UserManager.AddToRoleAsync(k, "Admin");

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

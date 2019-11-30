using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentralDeErros.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CentralDeErros.Api
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
            services.AddDbContext<ErrorDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("CentralDeErros")));

            services.AddDefaultIdentity<IdentityUser>()
                 .AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<ErrorDbContext>()
                 .AddDefaultTokenProviders();

            // pega as configurações do appsettings.json
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<Users>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret); //cria uma chave com o secret

            services.AddAuthentication(x =>//autenticação faz aqui
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),//gera chave segura
                    ValidateIssuer = true, //valida o emissor 
                    ValidateAudience = true, //valida a url
                    ValidateLifetime = true,
                    //ValidAudience = appSettings.ValidoEm, //informo qual é a url
                    //ValidIssuer = appSettings.Emissor //informo qual é o emissor do token
                };
            });

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("user", policy => policy.RequireClaim("CentralDeErros", "user"));
                //options.AddPolicy("admin", policy => policy.RequireClaim("CentralDeErros", "admin"));
            });

            services.AddMvc(//config =>
                            //{
                            //    var policy = new AuthorizationPolicyBuilder()
                            //                     .RequireAuthenticatedUser()
                            //                     .Build();
                            //    config.Filters.Add(new AuthorizeFilter(policy));
                            //}
                   ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();
            //TODO Usar o Identity na aplicação
            app.UseAuthentication();//usar autenticação
            app.UseMvc();

            
        }
    }
}

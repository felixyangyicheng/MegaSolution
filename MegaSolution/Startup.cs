using AutoMapper;
using MegaSolution.Contracts;
using MegaSolution.Data;
using MegaSolution.Mappings;
using MegaSolution.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.HttpOverrides;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaSolution
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
        {   //Sql Server
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));


            //MySql
            services.AddDbContext<ApplicationDbContext>(dbContextOptions =>
                dbContextOptions
                .UseMySql(
                    //"Server=172.16.1.114;Port=3306;Database=mysql-megasolution;Uid=root;Pwd=123456;",
                    "Server=192.168.1.45;Port=3306;Database=megasolution;Uid=app;Pwd=123456;",

                    new MySqlServerVersion(new Version(8, 0, 22)),
                     mySqlOptions => mySqlOptions
                            .CharSetBehavior(CharSetBehavior.NeverAppend))
                            .EnableDetailedErrors()
                            .EnableSensitiveDataLogging()
            );

            services.AddDefaultIdentity<ApplicationUser>()  //Added 07/05/2021 evo ArtistProfile
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddCors(o =>
            {
                o.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "MegaSolution", 
                    Version = "v1", 
                    Description="This is a api for MegaCasting administration"
                });
            });

            services.AddAutoMapper(typeof(Map));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                  .AddJwtBearer(o => {
                      o.TokenValidationParameters = new TokenValidationParameters
                      {
                          ValidateIssuer = true,
                          ValidateAudience = true,
                          ValidateLifetime = true,
                          ValidateIssuerSigningKey = true,
                          ValidIssuer = Configuration["Jwt:Issuer"],
                          ValidAudience = Configuration["Jwt:Issuer"],
                          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))

                      };
                  });

            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IContractTypeRepository, ContractTypeRepository>();
            services.AddScoped<IDiffusionPartnerRepository, DiffusionPartnerRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IProfessionRepository, ProfessionRepository>();
            services.AddScoped<IProfessionSectorRepository, ProfessionSectorRepository>();
            services.AddScoped<IStudioRepository, StudioRepository>();

            services.AddControllers().AddNewtonsoftJson(op =>
                op.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders=ForwardedHeaders.XForwardedFor| ForwardedHeaders.XForwardedProto
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MegaSolution v1"));
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MegaSolution v1"));
            }



            app.UseHttpsRedirection();

            UserData.Seed(userManager, roleManager).Wait();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

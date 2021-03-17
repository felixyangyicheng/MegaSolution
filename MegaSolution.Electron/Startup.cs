using Blazored.LocalStorage;
using Blazored.Toast;
using MegaSolution.Electron.Contracts;
using MegaSolution.Electron.Providers;
using MegaSolution.Electron.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ElectronNET.API;
using ElectronNET.API.Entities;

namespace MegaSolution.Electron
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AppData>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazorise(options =>
             {
                 options.ChangeTextOnKeyPress = true; // optional
             })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();

            services.AddBlazoredLocalStorage();
            services.AddBlazoredToast();
            services.AddHttpClient();
            services.AddScoped<ApiAuthenticationStateProvider>();
            services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());
            services.AddScoped<JwtSecurityTokenHandler>();
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IContractRepository, ContractRepository>();
            services.AddTransient<IContractTypeRepository, ContractTypeRepository>();
            services.AddTransient<IDiffusionPartnerRepository, DiffusionPartnerRepository>();
            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<IProfessionRepository, ProfessionRepository>();
            services.AddTransient<IProfessionSectorRepository, ProfessionSectorRepository>();
            services.AddTransient<IStudioRepository, StudioRepository>();
            services.AddTransient<IFileUpload, FileUpload>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.ApplicationServices
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            ElectronBootStrap();
        }
        
        void ElectronBootStrap()
        {
            Task.Run(async () => await ElectronNET.API.Electron.WindowManager.CreateWindowAsync());
        }
    }
}

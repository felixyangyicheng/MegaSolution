using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using MegaSolution.WebAssembly.Providers;
using System.IdentityModel.Tokens.Jwt;
using MegaSolution.WebAssembly.Contracts;
using MegaSolution.WebAssembly.Repositories;

namespace MegaSolution.WebAssembly
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services
              .AddBlazorise(options =>
              {
                  options.ChangeTextOnKeyPress = true;
              })
              .AddBootstrapProviders()
              .AddFontAwesomeIcons();
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddBlazoredToast(); 
            builder.Services.AddScoped<ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(p =>p.GetRequiredService<ApiAuthenticationStateProvider>());
            builder.Services.AddScoped<JwtSecurityTokenHandler>();
            builder.Services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            builder.Services.AddTransient<IArtistRepository, ArtistRepository>();
            builder.Services.AddTransient<IContractRepository, ContractRepository>();
            builder.Services.AddTransient<IContractTypeRepository, ContractTypeRepository>();
            builder.Services.AddTransient<IDiffusionPartnerRepository, DiffusionPartnerRepository>();
            builder.Services.AddTransient<IOfferRepository, OfferRepository>();
            builder.Services.AddTransient<IProfessionRepository, ProfessionRepository>();
            builder.Services.AddTransient<IProfessionSectorRepository, ProfessionSectorRepository>();
            builder.Services.AddTransient<IStudioRepository, StudioRepository>();
            //builder.Services.AddTransient<IFileUpload, FileUpload>();
            await builder.Build().RunAsync();
        }
    }
}

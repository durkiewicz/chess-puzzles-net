using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ChessNET
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<PuzzleRepository>();
            builder.Services.AddScoped<LegalMovesGenerator>();
            builder.Services.AddScoped<FenParser>();
            builder.Services.AddScoped<LocalStorage>();
            builder.Services.AddScoped<StateService>();
            builder.Services.AddScoped<ChessNavigationManager>();
            builder.Services.AddScoped<ChessTheme>();
            builder.Services.AddMatBlazor();
            await builder.Build().RunAsync();
        }
    }
}

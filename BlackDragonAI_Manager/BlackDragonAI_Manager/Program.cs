using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using BlackDragonAI_Manager.BlbApi;
using BlackDragonAI_Manager.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace BlackDragonAI_Manager
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            var contentSerializer = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var refitSettings = new RefitSettings()
            {
                ContentSerializer = new JsonContentSerializer(contentSerializer)
            };

            builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddRefitClient<IBlbApi>(refitSettings).ConfigureHttpClient(httpClient => 
                httpClient.BaseAddress = new Uri("https://blb-api.herokuapp.com/api"));
            builder.Services.AddSingleton<BlbApiHandler>();

            await builder.Build().RunAsync();
        }
    }
}

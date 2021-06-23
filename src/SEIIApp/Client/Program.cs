using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SEIIApp.Client {
    public class Program {
        public static async Task Main(string[] args) {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<Services.QuizDefinitionBackendAccessService>();
            builder.Services.AddScoped<Services.CourseDefinitionBackendAccessService>();
            builder.Services.AddScoped<Services.ChapterElementDefinitionBackendAccessService>();
            builder.Services.AddScoped<Services.TextElementDefinitionBackendAccessService>();
            builder.Services.AddScoped<Services.QuizElementDefinitionBackendAccessService>();
            builder.Services.AddScoped<Services.PictureElementDefinitionBackendAccessService>();
            builder.Services.AddScoped<Services.VideoElementDefinitionBackendAccessService>();
            builder.Services.AddScoped<Services.LoginBackendAccessService>();
            builder.Services.AddScoped<Services.UserDefinitionBackendService>();
            builder.Services.AddScoped<Services.BiscuitService>();
            builder.Services.AddScoped<Services.ChapterDefinitionBackendAccessService>();


            await builder.Build().RunAsync();
        }
    }
}

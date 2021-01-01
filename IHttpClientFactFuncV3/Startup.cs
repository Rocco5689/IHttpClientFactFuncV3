using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(IHttpClientFactFuncV3.Startup))]

namespace IHttpClientFactFuncV3
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Injecting client with base url configuration preset
            builder.Services.AddHttpClient<ICustomHttpClient, CustomHttpClient>(client =>
            {
                client.BaseAddress = new Uri("https://www.bing.com/");
            });
        }
    }
}

﻿using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Devpro.SalesPortal.BlazorWasmApp.Configuration
{
    public class ServiceUriGuesser
    {
        public static Uri GuessBackendUri(WebAssemblyHostBuilder builder)
        {
            var hostAddress = builder.HostEnvironment.BaseAddress;

            if (hostAddress == "http://localhost:5268/")
            {
                return new Uri("http://localhost:5261/");
            }

            if (hostAddress == "https://localhost:7212/")
            {
                return new Uri("https://localhost:7021/");
            }

            if (hostAddress == "http://localhost:9001/")
            {
                return new Uri("http://localhost:9002/");
            }

            return new Uri(hostAddress.Replace("sales-portal", "crm-adapter"));
        }
    }
}

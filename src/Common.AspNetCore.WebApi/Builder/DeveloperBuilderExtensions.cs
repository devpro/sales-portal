﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Devpro.Common.AspNetCore.WebApi.Builder
{
    public static class DeveloperBuilderExtensions
    {
        public static IApplicationBuilder UseDeveloperExceptionPage(this IApplicationBuilder app, IWebHostEnvironment environment)
        {
            if (environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            return app;
        }
    }
}

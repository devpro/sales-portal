namespace Devpro.SalesPortal.CrmAdapterWebApi.Builder
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

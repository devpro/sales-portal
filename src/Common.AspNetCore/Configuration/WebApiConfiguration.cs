using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Devpro.Common.AspNetCore.Configuration
{
    public class WebApiConfiguration
    {
        private readonly IConfiguration _configuration;

        public WebApiConfiguration(IConfigurationRoot configurationRoot)
        {
            _configuration = configurationRoot;
        }

        // flags

        public bool IsOpenTelemetryEnabled => TryGetSection("Application:IsOpenTelemetryEnabled").Get<bool>();

        public bool IsHttpsRedirectionEnabled => TryGetSection("Application:IsHttpsRedirectionEnabled").Get<bool>();

        public bool IsSwaggerEnabled => TryGetSection("Application:IsSwaggerEnabled").Get<bool>();

        // definitions

        public string CorsPolicyName => "RestrictedOrigins";

        public string HealthCheckEndpoint => "/health";

        public OpenApiInfo OpenApi => TryGetSection("OpenApi").Get<OpenApiInfo>() ?? throw new Exception("");

        public string OpenTelemetryService => TryGetSection("OpenTelemetry:ServiceName").Get<string>() ?? "";

        // infrastructure

        public List<string> CorsAllowedOrigin => TryGetSection("AllowedOrigins").Get<List<string>>() ?? new List<string>();

        public string OpenTelemetryCollectorEndpoint => TryGetSection("OpenTelemetry:CollectorEndpoint").Get<string>() ?? "";

        // private methods

        private IConfigurationSection TryGetSection(string sectionKey)
        {
            return _configuration.GetSection(sectionKey)
                ?? throw new ArgumentException("Missing section \"" + sectionKey + "\" in configuration", nameof(sectionKey));
        }
    }
}

﻿using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Devpro.Common.AspNetCore.WebApi.Configuration
{
    public class WebApiConfiguration(IConfigurationRoot configurationRoot)
    {
        protected IConfigurationRoot ConfigurationRoot { get; } = configurationRoot;

        // flags

        public bool IsOpenTelemetryEnabled => TryGetSection("Application:IsOpenTelemetryEnabled").Get<bool>();

        public bool IsHttpsRedirectionEnabled => TryGetSection("Application:IsHttpsRedirectionEnabled").Get<bool>();

        public bool IsSwaggerEnabled => TryGetSection("Application:IsSwaggerEnabled").Get<bool>();

        public bool IsCertificateValidationSkipped => TryGetSection("Application:IsCertificateValidationSkipped").Get<bool>();

        // definitions

        public static string CorsPolicyName => "RestrictedOrigins";

        public static string HealthCheckEndpoint => "/health";

        public OpenApiInfo OpenApi => TryGetSection("OpenApi").Get<OpenApiInfo>() ?? throw new Exception("OpenApi configuration missing");

        public string OpenTelemetryService => TryGetSection("OpenTelemetry:ServiceName").Get<string>() ?? "";

        // infrastructure

        public List<string> CorsAllowedOrigin => TryGetSection("AllowedOrigins").Get<List<string>>() ?? [];

        public string OpenTelemetryCollectorEndpoint => TryGetSection("OpenTelemetry:CollectorEndpoint").Get<string>() ?? "";

        public string OpenTelemetryCollectorAuthorization => TryGetSection("OpenTelemetry:CollectorAuthorization").Get<string>() ?? "";

        // protected methods

        protected IConfigurationSection TryGetSection(string sectionKey)
        {
            return ConfigurationRoot.GetSection(sectionKey)
                ?? throw new ArgumentException($"Missing section \"{sectionKey}\" in configuration", nameof(sectionKey));
        }
    }
}

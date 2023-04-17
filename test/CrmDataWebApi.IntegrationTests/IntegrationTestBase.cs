﻿using Microsoft.AspNetCore.Mvc.Testing;

namespace Devpro.SalesPortal.CrmDataWebApi.IntegrationTests
{
    /// <summary>
    /// See https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests
    /// </summary>
    public abstract class IntegrationTestBase : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        protected IntegrationTestBase(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        protected HttpClient CreateClient()
        {
            return _factory.CreateClient();
        }
    }
}

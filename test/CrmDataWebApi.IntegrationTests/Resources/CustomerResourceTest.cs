﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Devpro.SalesPortal.CrmDataWebApi.IntegrationTests.Resources
{
    /// <summary>
    /// See https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests
    /// </summary>
    public class CustomerResourceTest : IntegrationTestBase, IClassFixture<WebApplicationFactory<Program>>
    {
        public CustomerResourceTest(WebApplicationFactory<Program> factory)
            : base(factory)
        {
        }

        [Theory]
        [InlineData("/customers")]
        public async Task Get_CustomersReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Content.Headers.ContentType.Should().NotBeNull();
            response.Content.Headers.ContentType?.ToString().Should().Be("application/json; charset=utf-8");
        }
    }
}

using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Devpro.SalesPortal.CrmDataWebApi.IntegrationTests.Resources
{
    public class OpportunityResourceTest : IntegrationTestBase, IClassFixture<WebApplicationFactory<Program>>
    {
        public OpportunityResourceTest(WebApplicationFactory<Program> factory)
            : base(factory)
        {
        }

        [Theory]
        [InlineData("/opportunities")]
        public async Task Get_OpportunitiesReturnSuccessAndCorrectContentType(string url)
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

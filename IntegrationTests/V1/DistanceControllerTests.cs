using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace CompanyName.DistanceCalculator.IntegrationTests
{
    public class DistanceControllerTests : IClassFixture<WebApplicationFactory<CompanyName.DistanceCalculator.Startup>>
    {
        private readonly WebApplicationFactory<CompanyName.DistanceCalculator.Startup> _factory;
        private const string _controllerUrl = "/api/v1/Distance";

        public DistanceControllerTests(WebApplicationFactory<CompanyName.DistanceCalculator.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CalculateDistanceTest()
        {
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{_controllerUrl}?Latitude1=1&Longtitude1=1&Latitude2=1&Longtitude2=1");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}

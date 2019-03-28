using CompanyName.DistanceCalculator.Controllers;
using CompanyName.DistanceCalculator.V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompanyName.DistanceCalculator.UnitTests.V1.Controllers
{
    [TestClass]
    public class DistanceControllerTests
    {
        [TestMethod]
        public void CalculateDistanceTest_Ok()
        {
            var requestDto = new CalculateDistanceRequestDto()
            {
                Latitude1 = 53.297975,
                Longtitude1 = -6.372663,
                Latitude2 = 41.385101,
                Longtitude2 = -81.440440
            };

            DistanceController controller = new DistanceController();
            var output = controller.Get(requestDto);

            Assert.AreEqual(output.Result.GetType(), typeof(OkObjectResult));

            var responseDto = (CalculateDistanceResponseDto)((OkObjectResult)output.Result).Value;
            Assert.IsNotNull(responseDto);

            Assert.AreEqual(0, responseDto.Distance);
        }

        [TestMethod]
        public void CalculateDistanceTest_BadRequest()
        {
            var requestDto = new CalculateDistanceRequestDto()
            {
                Latitude1 = null,
                Longtitude1 = -6.372663,
                Latitude2 = 41.385101,
                Longtitude2 = -81.440440
            };

            DistanceController controller = new DistanceController();
            controller.ModelState.AddModelError("Latitude1", "The field Latitude1 is required");

            var output = controller.Get(requestDto);

            Assert.AreEqual(output.Result.GetType(), typeof(BadRequestObjectResult));
        }
    }
}

using CompanyName.DistanceCalculator.Controllers;
using CompanyName.DistanceCalculator.Services.Interfaces;
using CompanyName.DistanceCalculator.V1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CompanyName.DistanceCalculator.UnitTests.V1.Controllers
{
    [TestClass]
    public class DistanceControllerTests
    {
        [TestMethod]
        public void CalculateDistanceTest_Ok()
        {
            var calculator = new Mock<IDistanceCalculator>();

            var requestDto = new CalculateDistanceRequestDto()
            {
                Latitude1 = 53.297975,
                Longtitude1 = -6.372663,
                Latitude2 = 41.385101,
                Longtitude2 = -81.440440
            };


            DistanceController controller = new DistanceController(calculator.Object);
            var output = controller.Get(requestDto);

            calculator.Verify(p => p.Calculate(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Once);

            Assert.AreEqual(output.Result.GetType(), typeof(OkObjectResult));

            var responseDto = (CalculateDistanceResponseDto)((OkObjectResult)output.Result).Value;
            Assert.IsNotNull(responseDto);

            Assert.AreEqual(0, responseDto.Distance);
        }

        [TestMethod]
        public void CalculateDistanceTest_BadRequest()
        {
            var calculator = new Mock<IDistanceCalculator>();

            var requestDto = new CalculateDistanceRequestDto()
            {
                Latitude1 = null,
                Longtitude1 = -6.372663,
                Latitude2 = 41.385101,
                Longtitude2 = -81.440440
            };

            DistanceController controller = new DistanceController(calculator.Object);
            controller.ModelState.AddModelError("Latitude1", "The field Latitude1 is required");

            var output = controller.Get(requestDto);

            calculator.Verify(p => p.Calculate(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()), Times.Never);

            Assert.AreEqual(output.Result.GetType(), typeof(BadRequestObjectResult));
        }
    }
}

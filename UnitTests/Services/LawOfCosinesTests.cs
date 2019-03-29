using CompanyName.DistanceCalculator.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CompanyName.DistanceCalculator.UnitTests.Services
{
    /*
      Expected results produced by SQL Server Geography library. 
      The folowing script was used to get data we considering correct in unit tests
      https://docs.microsoft.com/en-us/sql/t-sql/spatial-geography/stdistance-geography-data-type?view=sql-server-2017
      
        declare @GetLoc1 GEOGRAPHY, @GetLoc2 GEOGRAPHY;

        select 
	        @GetLoc1 = GEOGRAPHY::Point(53.297975, -6.372663,  4326), 
	        @GetLoc2 = GEOGRAPHY::Point(41.385101, -81.440440,  4326)

        select  @GetLoc1.STDistance(@GetLoc2) /1000

    */
    [TestClass]
    public class LawOfCosinesTests
    {
        [TestMethod]
        public void CalculateDistance_BigDistance()
        {
            LawOfCosines strategy = new LawOfCosines();
            double actual = strategy.Calculate(53.297975, -6.372663, 41.385101, -81.440440);

            //template result
            double expected = 5551.4943863474;

            //for big distance allow +- 20 km difference
            Assert.IsTrue(Between(actual, expected - 20, expected + 20));
        }

        [TestMethod]
        public void CalculateDistance_MediumDistance()
        {
            LawOfCosines strategy = new LawOfCosines();
            double actual = strategy.Calculate(49.9947277, 36.1457427, 50.402170, 30.3926086);

            //template result
            double expected = 413.161648901836;

            //for medium distance allow +- 5 km difference
            Assert.IsTrue(Between(actual, expected - 5, expected + 5));
        }


        [TestMethod]
        public void CalculateDistance_SmallDistance()
        {
            LawOfCosines strategy = new LawOfCosines();
            double actual = strategy.Calculate(53.342154, -6.1544591, 53.3370977, -6.2614925);

            //template result
            double expected = 7.15158339775568;

            //for small distance allow +- 0.2 km difference
            Assert.IsTrue(Between(actual, expected - 0.2, expected + 0.2));
        }


        [TestMethod]
        public void CalculateDistance_HalfLengthOnEquator()
        {
            LawOfCosines strategy = new LawOfCosines();
            double actual = strategy.Calculate(0, 0, 0, -180);

            //template result. Earth lenght on equator is 40,075 kilometers.
            double expected = 20037.5;

            //allow +- 50 km difference
            Assert.IsTrue(Between(actual, expected -50, expected + 50));
        }

        private bool Between(double dec, double min, double max)
        {
            return dec >= min && dec <= max;
        }
    }
        
    
}

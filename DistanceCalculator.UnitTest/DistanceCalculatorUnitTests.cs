using DistanceCalculator.Domain;
using DistanceCalculator.Domain.ViewModel;
using DistanceCalculator.ServiceLayer.Implementation;
using DistanceCalculator.ServiceLayer.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DistanceCalculator.UnitTest
{
    [TestClass]
    public class DistanceCalculatorUnitTests
    {
        private IGeoPositionCalculator _igeoPositionCalculator;

        [TestInitialize]
        public void Initialize()
        {
            _igeoPositionCalculator = new GeoPositionCalculator();
        }
        [TestMethod]
        public void GetDistanceTest()
        {
            var coordinates = new Coordinates
            {
                From = new GeoPositions { Latitude = 56.56556, Longitude = -95.56556 },
                To = new GeoPositions { Latitude = 50.56556, Longitude = -90.56556 }
            };
            var distance = _igeoPositionCalculator.GetDistanceAsync(coordinates.From, coordinates.To).Result;

            Assert.AreEqual(743.94252237583862, distance);
        }

        [TestMethod]
        public void GetDistanceOverFlowCoordinateTest()
        {
            var coordinates = new Coordinates
            {
                From = new GeoPositions { Latitude = double.MinValue - 1, Longitude = -95.56556 },
                To = new GeoPositions { Latitude = double.MaxValue + 1, Longitude = -95.56556 }
            };
            var distance = _igeoPositionCalculator.GetDistanceAsync(coordinates.From, coordinates.To).Result;
            Assert.AreEqual(double.MinValue, distance);
        }
    }
}

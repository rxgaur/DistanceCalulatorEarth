using DistanceCalculator.Domain;
using DistanceCalculator.Domain.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace DistanceCalculator.IntegrationTests
{
    [TestClass]
    public class DistanceCalculatorIntegrationTest : TestClientProvider
    {

        [TestMethod]
        public void GetDistanceStatusTest()
        {
            var coordinates = new Coordinates
            {
                From = new GeoPositions { Latitude = 56.56556, Longitude = -95.56556 },
                To = new GeoPositions { Latitude = 50.56556, Longitude = -90.56556 }
            };

            using var request = new HttpRequestMessage(new HttpMethod("GET"), @"/DistanceCalculation/GetDistance")
            {
                Version = new Version(1, 0),
                Content = new StringContent(JsonConvert.SerializeObject(coordinates), Encoding.UTF8, "application/json")

            };
            using (var client = new TestClientProvider().Client)
            {
                var response = client.SendAsync(request).Result;
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [TestMethod]
        public void GetDistanceWithSameCoordinatesTest()
        {
            var coordinates = new Coordinates
            {
                From = new GeoPositions { Latitude = 56.56556, Longitude = -95.56556 },
                To = new GeoPositions { Latitude = 56.56556, Longitude = -95.56556 }
            };

            using (var request = new HttpRequestMessage(new HttpMethod("GET"), @"/DistanceCalculation/GetDistance")
            {
                Version = new Version(1, 0),
                Content = new StringContent(JsonConvert.SerializeObject(coordinates), Encoding.UTF8, "application/json")

            })
            {
                using (var client = new TestClientProvider().Client)
                {
                    var response = client.SendAsync(request).Result;
                    Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                }
            }
        }
    }
}

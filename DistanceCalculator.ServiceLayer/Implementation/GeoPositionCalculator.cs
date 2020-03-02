using DistanceCalculator.Domain;
using DistanceCalculator.ServiceLayer.Interface;
using System;
using System.Threading.Tasks;

namespace DistanceCalculator.ServiceLayer.Implementation
{
    public class GeoPositionCalculator : IGeoPositionCalculator
    {
        public async Task<double> GetDistanceAsync(GeoPositions from, GeoPositions to)
        {
            if (from.Longitude >= -180 && to.Longitude <= 180 && from.Latitude >= -90 && to.Latitude <= 90)
            {
                const double earthRadius = 6371;
                double d;
                try
                {
                    var φ1 = to.Latitude * Math.PI / 180;
                    var φ2 = from.Latitude * Math.PI / 180;
                    var Δλ = (to.Longitude - from.Longitude) * Math.PI / 180;

                    d = await Task.Run(() => Math.Acos(Math.Sin(φ1) * Math.Sin(φ2) + Math.Cos(φ1) * Math.Cos(φ2) * Math.Cos(Δλ)));

                }
                catch (Exception e)
                {
                    //Logging the Exception here;
                    throw;
                }

                return earthRadius * d;
            }

            return double.MinValue;
        }
    }
}

using DistanceCalculator.Domain;

namespace DistanceCalculator.ServiceLayer
{
    public static class ExtensionMethods
    {
        public static bool IsEqual(this GeoPositions to, GeoPositions from)
        {
            return to.Latitude.Equals(from.Latitude) && to.Longitude.Equals(from.Longitude);
        }
    }
}

using DistanceCalculator.Domain;
using System.Threading.Tasks;

namespace DistanceCalculator.ServiceLayer.Interface
{
    public interface IGeoPositionCalculator
    {
        Task<double> GetDistanceAsync(GeoPositions from, GeoPositions to);
    }
}

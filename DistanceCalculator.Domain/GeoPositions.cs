using System.ComponentModel.DataAnnotations;

namespace DistanceCalculator.Domain
{
    public class GeoPositions
    {
        [Required]
        [Range(-90, 90, ErrorMessage = "Can only be between -90 .. 90")]
        public double Latitude { get; set; }

        [Required]
        [Range(-180, 180, ErrorMessage = "Can only be between -180 .. 180")]
        public double Longitude { get; set; }
    }
}

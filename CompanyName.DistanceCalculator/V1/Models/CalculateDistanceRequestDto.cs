using System.ComponentModel.DataAnnotations;

namespace CompanyName.DistanceCalculator.V1.Models
{
    public class CalculateDistanceRequestDto
    {
        [Required]
        public double? Latitude1 { get; set; }
        [Required]
        public double? Longtitude1 { get; set; }
        [Required]
        public double? Latitude2 { get; set; }
        [Required]
        public double? Longtitude2 { get; set; }
    }
}

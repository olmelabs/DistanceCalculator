using System.ComponentModel.DataAnnotations;

namespace CompanyName.DistanceCalculator.V1.Models
{
    public class CalculateDistanceResponseDto
    {
        public CalculateDistanceResponseDto(double distance)
        {
            Distance = distance;
        }

        public double Distance { get; }
    }
}

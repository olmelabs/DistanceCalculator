using CompanyName.DistanceCalculator.Services.Interfaces;
using System;

namespace CompanyName.DistanceCalculator.Services.Implementations
{
    public class LawOfCosines : IDistanceCalculator
    {
        const double _earthRadiusKm = 6371;

        /// <summary>
        /// calculates distance between 2 set of coordinates using Law of Cosines
        /// </summary>
        /// <param name="Latitude1">Point 1 Latitude</param>
        /// <param name="Longtitude1">Point 1 Longtitude</param>
        /// <param name="Latitude2">Point 2 Latitude</param>
        /// <param name="Longtitude2">Point 2 Longtitude</param>
        /// <returns>Distance between two point in KM</returns>
        public double Calculate(double Latitude1, double Longtitude1, double Latitude2, double Longtitude2)
        {
            if (Latitude1 == Latitude2 && Longtitude1 == Longtitude2)
                return 0;

            double a = Degree2Radian(90 - Latitude2);
            double b = Degree2Radian(90 - Latitude1);
            double phi = Degree2Radian(Longtitude1 - Longtitude2);

            double cosP = Math.Cos(a) * Math.Cos(b) + Math.Sin(a) * Math.Sin(b) * Math.Cos(phi);

            return Math.Acos(cosP) * _earthRadiusKm; ;
        }

        private double Degree2Radian(double deg)
        {
            return (deg * Math.PI / 180.0);
        }
    }
}

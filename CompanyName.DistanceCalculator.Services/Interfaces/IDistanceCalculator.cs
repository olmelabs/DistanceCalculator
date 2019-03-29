namespace CompanyName.DistanceCalculator.Services.Interfaces
{
    public interface IDistanceCalculator
    {
        double Calculate(double Latitude1, double Longtitude1, double Latitude2, double Longtitude2);
    }
}

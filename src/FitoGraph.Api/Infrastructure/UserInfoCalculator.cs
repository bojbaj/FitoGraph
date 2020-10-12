namespace FitoGraph.Api.Infrastructure
{
    public static class UserInfoCalculator
    {
        public static decimal GetBMI(decimal HeightInMeter, decimal Weight)
        {
            decimal _BMI = (HeightInMeter == 0) ? 0 : (Weight / (HeightInMeter * HeightInMeter));
            return _BMI;
        }
    }
}
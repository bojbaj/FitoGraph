using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Infrastructure
{
    public static class UserInfoCalculator
    {
        public static decimal GetBMI(decimal HeightInMeter, decimal Weight)
        {
            decimal _BMI = (HeightInMeter == 0) ? 0 : (Weight / (HeightInMeter * HeightInMeter));
            return _BMI.ToString("N2").toDecimal(0);
        }
        public static BmiLabelEnum GetBmiStatus(decimal BMI)
        {
            switch (BMI)
            {
                case 0:
                    return BmiLabelEnum.NULL;
                case var _ when (BMI < 18.5M):
                    return BmiLabelEnum.UnderWeight;
                case var _ when (BMI < 25M):
                    return BmiLabelEnum.Normal;
                case var _ when (BMI < 30M):
                    return BmiLabelEnum.OverWeight;
                default:
                    return BmiLabelEnum.Obese;
            }
        }
        public static string GetWaistToHipsRatioStatus(GenderEnum Gender, decimal WaistToHipsRatio)
        {
            if (Gender == GenderEnum.MALE)
            {
                switch (WaistToHipsRatio)
                {
                    case 0:
                        return WaistToHipsRatioEnum.NULL.ToString();
                    case var _ when (WaistToHipsRatio < 0.85M):
                        return WaistToHipsRatioEnum.EXCELENT.ToString();
                    case var _ when (WaistToHipsRatio <= 0.89M):
                        return WaistToHipsRatioEnum.GOOD.ToString();
                    case var _ when (WaistToHipsRatio <= 0.95M):
                        return WaistToHipsRatioEnum.AVERAGE.ToString();
                    default:
                        return WaistToHipsRatioEnum.AT_RISK.ToString();
                }
            }
            else if (Gender == GenderEnum.FEMALE)
            {
                switch (WaistToHipsRatio)
                {
                    case 0:
                        return WaistToHipsRatioEnum.NULL.ToString();
                    case var _ when (WaistToHipsRatio < 0.75M):
                        return WaistToHipsRatioEnum.EXCELENT.ToString();
                    case var _ when (WaistToHipsRatio <= 0.79M):
                        return WaistToHipsRatioEnum.GOOD.ToString();
                    case var _ when (WaistToHipsRatio <= 0.86M):
                        return WaistToHipsRatioEnum.AVERAGE.ToString();
                    default:
                        return WaistToHipsRatioEnum.AT_RISK.ToString();
                }
            }
            else
            {
                return WaistToHipsRatioEnum.NULL.ToString();
            }
        }
        public static decimal GetMBR(GenderEnum Gender, decimal Weight, decimal Height, int Age)
        {
            decimal _BMR = 0;
            if (Gender == GenderEnum.MALE)
            {
                _BMR = ((10 * Weight) + (6.25M * Height) - (5 * Age) + 5);
            }
            else if (Gender == GenderEnum.FEMALE)
            {
                _BMR = ((10 * Weight) + (6.25M * Height) - (5 * Age) - 161);
            }
            return _BMR.ToString("N2").toDecimal(0);
        }
        public static decimal GetDailyCalories(GenderEnum Gender, decimal BMR, decimal ActivityLevelPalForMale, decimal ActivityLevelPalForFemale)
        {
            decimal _DailyCalories = 0;
            if (Gender == GenderEnum.MALE)
            {
                _DailyCalories = BMR * ActivityLevelPalForMale;
            }
            else if (Gender == GenderEnum.FEMALE)
            {
                _DailyCalories = BMR * ActivityLevelPalForFemale;
            }
            return _DailyCalories.ToString("N2").toDecimal(0);
        }
    }
}
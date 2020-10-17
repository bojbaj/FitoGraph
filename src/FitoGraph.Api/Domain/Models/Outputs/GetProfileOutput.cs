using System;
using System.Collections.Generic;
using FitoGraph.Api.Domain.Entities;
using FitoGraph.Api.Infrastructure;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetProfileOutput
    {
        public string FireBaseId { get; set; }
        public bool Enabled { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int RegionCountryId { get; set; }
        public int RegionStateId { get; set; }
        public int RegionCityId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Waist { get; set; }
        public decimal Hips { get; set; }
        public decimal Forearms { get; set; }
        public decimal Fat { get; set; }
        public decimal TargetWeight { get; set; }
        public decimal ActivityLevelPalForMale { get; set; }
        public decimal ActivityLevelPalForFemale { get; set; }
        public decimal ActivityLevelCarb { get; set; }
        public decimal ActivityLevelProtein { get; set; }
        public int ActivityLevelId { get; set; }
        public int GoalId { get; set; }
        public int WeeklyGoalId { get; set; }
        public BodyTypeOutput BodyType { get; set; }
        public int Gender { get; set; }

        #region Calculations
        private GenderEnum GenderEn { get { return Enum.Parse<GenderEnum>(Gender.ToString()); } }
        private decimal HeightInMeter { get { return Height / 100.0M; } }
        public int Age
        {
            get
            {
                return (DateTime.Now.Year - BirthYear);
            }
        }
        private decimal _BMI;
        public decimal BMI
        {
            get
            {
                if (_BMI != 0)
                    return _BMI.ToString("N2").toDecimal(0);

                _BMI = UserInfoCalculator.GetBMI(HeightInMeter, Weight);
                return _BMI.ToString("N2").toDecimal(0);
            }
        }
        public string BMI_Status
        {
            get
            {
                return UserInfoCalculator.GetBmiStatus(BMI).ToString();
            }
        }

        private decimal _WaistToHipsRatio;
        public decimal WaistToHipsRatio
        {
            get
            {
                if (_WaistToHipsRatio != 0)
                    return _WaistToHipsRatio;

                _WaistToHipsRatio = (Hips == 0.0M) ? 0 : (Waist / Hips);
                return _WaistToHipsRatio.ToString("N2").toDecimal(0);
            }
        }
        public string WaistToHipsRatioStatus
        {
            get
            {
                return UserInfoCalculator.GetWaistToHipsRatioStatus(GenderEn, WaistToHipsRatio);
            }
        }
        private decimal _BMR;
        public decimal BMR
        {
            get
            {
                if (_BMR != 0)
                    return _BMR;

                _BMR = UserInfoCalculator.GetMBR(GenderEn, Weight, Height, Age);
                return _BMR;
            }
        }
        private decimal _DailyCalories;
        public decimal DailyCalories
        {
            get
            {
                if (_DailyCalories != 0)
                    return _DailyCalories;

                _DailyCalories = UserInfoCalculator.GetDailyCalories(GenderEn, BMR, ActivityLevelPalForMale, ActivityLevelPalForFemale);
                return _DailyCalories;
            }
        }
        private decimal _DailyCarbInGram;
        public decimal DailyCarbInGram
        {
            get
            {
                if (_DailyCarbInGram != 0)
                    return _DailyCarbInGram.ToString("N2").toDecimal(0);

                if (DailyCalories > 0.0M)
                    _DailyCarbInGram = ActivityLevelCarb * Weight;
                return _DailyCarbInGram.ToString("N2").toDecimal(0);
            }
        }

        private decimal _DailyCarbInCalory;
        public decimal DailyCarbInCalory
        {
            get
            {
                if (_DailyCarbInCalory != 0)
                    return _DailyCarbInCalory.ToString("N2").toDecimal(0);

                _DailyCarbInCalory = DailyCarbInGram * 4;
                return _DailyCarbInCalory.ToString("N2").toDecimal(0);
            }
        }
        private decimal _DailyProteinInGram;
        public decimal DailyProteinInGram
        {
            get
            {
                if (_DailyProteinInGram != 0)
                    return _DailyProteinInGram.ToString("N2").toDecimal(0);

                if (DailyCalories > 0.0M)
                    _DailyProteinInGram = ActivityLevelProtein * Weight;
                return _DailyProteinInGram.ToString("N2").toDecimal(0);
            }
        }
        private decimal _DailyProteinInCalory;
        public decimal DailyProteinInCalory
        {
            get
            {
                if (_DailyProteinInCalory != 0)
                    return _DailyProteinInCalory.ToString("N2").toDecimal(0);

                _DailyProteinInCalory = DailyProteinInGram * 4;
                return _DailyProteinInCalory.ToString("N2").toDecimal(0);
            }
        }
        private decimal _DailyFatInCalory;
        public decimal DailyFatInCalory
        {
            get
            {
                if (_DailyFatInCalory != 0)
                    return _DailyFatInCalory.ToString("N2").toDecimal(0);

                if (DailyCalories > 0.0M)
                    _DailyFatInCalory = (DailyCalories - DailyProteinInCalory - DailyCarbInCalory);
                return _DailyFatInCalory.ToString("N2").toDecimal(0);
            }
        }
        private decimal _DailyFatInGram;
        public decimal DailyFatInGram
        {
            get
            {
                if (_DailyFatInGram != 0)
                    return _DailyFatInGram.ToString("N2").toDecimal(0);

                _DailyFatInGram = DailyFatInCalory / 9;
                return _DailyFatInGram.ToString("N2").toDecimal(0);
            }
        }
        public CustomerStateEnum CustomerState
        {
            get
            {
                if (BMI == 0)
                {
                    return CustomerStateEnum.PROFILE_NOT_COMPLETED;
                }
                else
                {
                    return CustomerStateEnum.READY;
                }
            }
        }
        #endregion
    }
}
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

        public TBodyType BodyType { get; set; }

        #region Calculations
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
                switch (BMI)
                {
                    case 0:
                        return BmiLabelEnum.NULL.ToString();
                    case var _ when (BMI < 18.5M):
                        return BmiLabelEnum.UnderWeight.ToString();
                    case var _ when (BMI < 25M):
                        return BmiLabelEnum.Normal.ToString();
                    case var _ when (BMI < 30M):
                        return BmiLabelEnum.OverWeight.ToString();
                    default:
                        return BmiLabelEnum.Obese.ToString();
                }
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
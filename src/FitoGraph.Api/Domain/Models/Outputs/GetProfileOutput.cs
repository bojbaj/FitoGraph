using System;
using System.Collections.Generic;
using FitoGraph.Api.Domain.Entities;
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
        public TBodyType BodyType { get; set; }

        #region Calculations
        public int Age
        {
            get
            {
                return (DateTime.Now.Year - BirthYear);
            }
        }
        public decimal BMI
        {
            get
            {
                return 0;
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
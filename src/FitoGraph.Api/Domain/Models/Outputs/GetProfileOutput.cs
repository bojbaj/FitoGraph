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

        #region Reloations
        public TBodyType BodyType { get; set; }
        public ICollection<TUserFoodType> UserFoodTypes { get; set; }
        public ICollection<TUserNutritionCondition> UserNutritionConditions { get; set; }
        public ICollection<TUserSport> UserSports { get; set; }
        public ICollection<TUserAllergy> UserAllergies { get; set; }
        public ICollection<TUserDiet> UserDiets { get; set; }
        public ICollection<TUserDeficiency> UserDeficiencies { get; set; }
        #endregion

        #region Calculations
        public int Age
        {
            get
            {
                return 0;
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
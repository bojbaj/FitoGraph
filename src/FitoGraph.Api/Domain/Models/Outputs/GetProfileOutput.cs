using System.Collections.Generic;
using FitoGraph.Api.Domain.Entities;

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
        public TBodyType TBodyType { get; set; }
        public ICollection<TUserFoodType> TUserFoodTypes { get; set; }
        public ICollection<TUserNutritionCondition> TUserNutritionConditions { get; set; }
        public ICollection<TUserSport> TUserSports { get; set; }
        public ICollection<TUserAllergy> TUserAllergies { get; set; }
        public ICollection<TUserDiet> TUserDiets { get; set; }
        public ICollection<TUserDeficiency> TUserDeficiencies { get; set; }
    }
}
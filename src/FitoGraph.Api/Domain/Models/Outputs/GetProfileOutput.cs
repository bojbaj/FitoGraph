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
        public TBodyType BodyType { get; set; }
        public ICollection<TUserFoodType> UserFoodTypes { get; set; }
        public ICollection<TUserNutritionCondition> UserNutritionConditions { get; set; }
        public ICollection<TUserSport> UserSports { get; set; }
        public ICollection<TUserAllergy> UserAllergies { get; set; }
        public ICollection<TUserDiet> UserDiets { get; set; }
        public ICollection<TUserDeficiency> UserDeficiencies { get; set; }
    }
}
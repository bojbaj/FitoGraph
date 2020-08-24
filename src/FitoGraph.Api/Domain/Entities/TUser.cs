using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TUser : BaseEntity
    {
        public string FireBaseId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? TBodyTypeId { get; set; }

        public TBodyType TBodyType { get; set; }

        public ICollection<TUserFoodType> TUserFoodTypes { get; set; }
        public ICollection<TUserNutritionCondition> TUserNutritionConditions { get; set; }
        public ICollection<TUserSport> TUserSports { get; set; }
        public ICollection<TUserAllergy> TUserAllergies { get; set; }
        public ICollection<TUserDiet> TUserDiets { get; set; }
        public ICollection<TUserDeficiency> TUserDeficiencies { get; set; }
    }
}
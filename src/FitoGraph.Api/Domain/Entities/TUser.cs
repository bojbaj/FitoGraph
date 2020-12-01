using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitoGraph.Api.Domain.Entities
{
    public class TUser : BaseEntity
    {
        public string FireBaseId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string RestaurantName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public int BirthYear { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Weight { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Height { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Waist { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Hips { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Forearms { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Fat { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal TargetWeight { get; set; }
        public int? TRegionCityId { get; set; }
        public int Gender { get; set; }
        public int? TBodyTypeId { get; set; }
        public int? TActivityLevelId { get; set; }
        public int? TWeeklyGoalId { get; set; }
        public int? TReferenceId { get; set; }
        public TReference TReference { get; set; }
        public Infrastructure.AppEnums.RoleEnum Role { get; set; }
        public TRegionCity TRegionCity { get; set; }
        public TBodyType TBodyType { get; set; }
        public TActivityLevel TActivityLevel { get; set; }
        public TWeeklyGoal TWeeklyGoal { get; set; }

        public ICollection<TUserFoodType> TUserFoodTypes { get; set; }
        public ICollection<TUserNutritionCondition> TUserNutritionConditions { get; set; }
        public ICollection<TUserSport> TUserSports { get; set; }
        public ICollection<TUserAllergy> TUserAllergies { get; set; }
        public ICollection<TUserDiet> TUserDiets { get; set; }
        public ICollection<TUserDeficiency> TUserDeficiencies { get; set; }
        public ICollection<TFood> TFoods { get; set; }
    }
}
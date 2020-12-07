using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitoGraph.Api.Domain.Entities
{
    public class TFood : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Tags { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public int TReferenceId { get; set; }
        public TReference TReference { get; set; }
        public int TFoodTypeId { get; set; }
        public TFoodType TFoodType { get; set; }
        public int TUserId { get; set; }
        public TUser TUser { get; set; }
        public ICollection<TFoodNutrition> TFoodNutritions { get; set; }
        public ICollection<TFoodNutritionCondition> TFoodNutritionConditions { get; set; }
        public ICollection<TFoodAllergy> TFoodAllergies { get; set; }
        public ICollection<TFoodDiet> TFoodDiets { get; set; }
        public ICollection<TFoodDeficiency> TFoodDeficiencies { get; set; }
    }
}
using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TNutritionCondition : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<TUserNutritionCondition> TUserNutritionConditions { get; set; }
        public ICollection<TFoodNutritionCondition> TFoodNutritionConditions { get; set; }
    }
}
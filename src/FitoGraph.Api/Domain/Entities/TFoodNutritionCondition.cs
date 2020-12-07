using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TFoodNutritionCondition : BaseEntity
    {
        public int TFoodId { get; set; }
        public int TNutritionConditionId { get; set; }
        public TFood TFood { get; set; }
        public TNutritionCondition TNutritionCondition { get; set; }
    }
}
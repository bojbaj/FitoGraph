using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TUserNutritionCondition : BaseEntity
    {
        public int TUserId { get; set; }
        public int TNutritionConditionId { get; set; }
        public TUser TUser { get; set; }
        public TNutritionCondition TNutritionCondition { get; set; }
    }
}
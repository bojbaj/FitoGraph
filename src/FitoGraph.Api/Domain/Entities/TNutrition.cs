using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TNutrition : BaseEntity
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public int TNutritionGroupId { get; set; }
        public TNutritionGroup TNutritionGroup { get; set; }
        public int TReferenceId { get; set; }
        public TReference TReference { get; set; }
    }
}
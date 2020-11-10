using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TNutritionGroup : BaseEntity
    {
        public string Title { get; set; }
        public int Code { get; set; }
        public string Image { get; set; }
        public ICollection<TNutrition> TNutritions { get; set; }
    }
}
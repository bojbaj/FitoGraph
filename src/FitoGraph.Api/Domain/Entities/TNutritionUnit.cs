using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TNutritionUnit : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int AmountInGram { get; set; }
        public ICollection<TFoodNutrition> TFoodNutritions { get; set; }
    }
}
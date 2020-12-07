using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TFoodDiet : BaseEntity
    {
        public int TFoodId { get; set; }
        public int TDietId { get; set; }
        public TFood TFood { get; set; }
        public TDiet TDiet { get; set; }
    }
}
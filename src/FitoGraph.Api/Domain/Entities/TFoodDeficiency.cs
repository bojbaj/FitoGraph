using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TFoodDeficiency : BaseEntity
    {
        public int TFoodId { get; set; }
        public int TDeficiencyId { get; set; }
        public TFood TFood { get; set; }
        public TDeficiency TDeficiency { get; set; }
    }
}
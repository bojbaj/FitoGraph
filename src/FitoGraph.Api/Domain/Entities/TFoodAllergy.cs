using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TFoodAllergy : BaseEntity
    {
        public int TFoodId { get; set; }
        public int TAllergyId { get; set; }
        public TFood TFood { get; set; }
        public TAllergy TAllergy { get; set; }
    }
}
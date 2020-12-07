using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TAllergy : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<TUserAllergy> TUserAllergies { get; set; }
        public ICollection<TFoodAllergy> TFoodAllergies { get; set; }
    }
}
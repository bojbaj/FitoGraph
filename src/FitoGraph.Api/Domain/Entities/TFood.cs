using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TFood : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int TReferenceId { get; set; }
        public TReference TReference { get; set; }
        public int TFoodTypeId { get; set; }
        public TFoodType TFoodType { get; set; }
    }
}
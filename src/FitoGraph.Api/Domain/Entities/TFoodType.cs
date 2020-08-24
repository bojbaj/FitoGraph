using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TFoodType : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<TUserFoodType> TUserFoodTypes { get; set; }
    }
}
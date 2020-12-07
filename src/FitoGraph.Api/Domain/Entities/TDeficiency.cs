using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TDeficiency : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<TUserDeficiency> TUserDeficiencies { get; set; }
        public ICollection<TFoodDeficiency> TFoodDeficiencies { get; set; }
    }
}
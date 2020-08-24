using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TDiet : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<TUserDiet> TUserDiets { get; set; }
    }
}
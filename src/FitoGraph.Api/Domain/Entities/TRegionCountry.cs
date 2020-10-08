using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TRegionCountry : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<TRegionState> TRegionStates { get; set; }
    }
}
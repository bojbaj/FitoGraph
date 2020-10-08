using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TRegionState : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int TRegionCountryId { get; set; }
        public TRegionCountry TRegionCountry { get; set; }
        public ICollection<TRegionCity> TRegionCities { get; set; }
    }
}
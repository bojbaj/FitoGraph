using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TRegionCity : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int TRegionStateId { get; set; }
        public TRegionState TRegionState { get; set; }
        public ICollection<TUser> TUsers { get; set; }        
    }
}
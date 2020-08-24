using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TSport : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<TUserSport> TUserSports { get; set; }
    }
}
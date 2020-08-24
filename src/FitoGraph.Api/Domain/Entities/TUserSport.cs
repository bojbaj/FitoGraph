using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TUserSport : BaseEntity
    {
        public int TUserId { get; set; }
        public int TSportId { get; set; }
        public TUser TUser { get; set; }
        public TSport TSport { get; set; }
    }
}
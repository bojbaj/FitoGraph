using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TUserDeficiency : BaseEntity
    {
        public int TUserId { get; set; }
        public int TDeficiencyId { get; set; }
        public TUser TUser { get; set; }
        public TDeficiency TDeficiency { get; set; }
    }
}
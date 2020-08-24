using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TUserDiet : BaseEntity
    {
        public int TUserId { get; set; }
        public int TDietId { get; set; }
        public TUser TUser { get; set; }
        public TDiet TDiet { get; set; }
    }
}
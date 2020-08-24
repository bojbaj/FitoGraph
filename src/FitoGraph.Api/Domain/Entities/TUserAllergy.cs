using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TUserAllergy : BaseEntity
    {
        public int TUserId { get; set; }
        public int TAllergyId { get; set; }
        public TUser TUser { get; set; }
        public TAllergy TAllergy { get; set; }
    }
}
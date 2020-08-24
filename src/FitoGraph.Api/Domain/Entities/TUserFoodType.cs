using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TUserFoodType : BaseEntity
    {
        public int TUserId { get; set; }
        public int TFoodTypeId { get; set; }
        public TUser TUser { get; set; }
        public TFoodType TFoodType { get; set; }
    }
}
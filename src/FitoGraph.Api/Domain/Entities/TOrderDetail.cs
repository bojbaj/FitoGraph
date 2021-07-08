using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitoGraph.Api.Domain.Entities
{
    public class TOrderDetail : BaseEntity
    {
        public int TFoodId { get; set; }
        public int Amount { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal RowPrice { get; set; }
        public int TUserId { get; set; }
        public int TOrderId { get; set; }
        public TFood TFood { get; set; }
        public TUser TUser { get; set; }
        public TOrder TOrder { get; set; }
    }
}
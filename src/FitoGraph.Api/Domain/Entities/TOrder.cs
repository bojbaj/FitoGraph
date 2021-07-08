using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitoGraph.Api.Domain.Entities
{
    public class TOrder : BaseEntity
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public string TrackingCode { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalPayablePrice { get; set; }
        public int TUserId { get; set; }

        [ForeignKey("TUserId")]
        public TUser TUser { get; set; }
        public int TSupplierId { get; set; }
        [ForeignKey("TSupplierId")]
        public TUser TSupplier { get; set; }

        public ICollection<TOrderDetail> TOrderDetails { get; set; }
    }
}
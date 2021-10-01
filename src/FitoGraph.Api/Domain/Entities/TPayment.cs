using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitoGraph.Api.Domain.Entities
{
    public class TPayment : BaseEntity
    {
        public Guid UniqueId { get; set; }
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public bool Success { get; set; }
        public bool Used { get; set; }
        public int OrderId { get; set; }
    }
}
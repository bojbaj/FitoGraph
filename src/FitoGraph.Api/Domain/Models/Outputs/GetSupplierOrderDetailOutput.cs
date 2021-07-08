using System;
using System.Collections.Generic;
using FitoGraph.Api.Domain.Entities;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetSupplierOrderDetailOutput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPayablePrice { get; set; }
        public string Customer { get; set; }
        public List<OrderDetailItem> list { get; set; }
        public class OrderDetailItem
        {
            public int Id { get; set; }
            public int FoodId { get; set; }
            public string FoodName { get; set; }
            public int Amount { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal RowPrice { get; set; }
        }
    }
}
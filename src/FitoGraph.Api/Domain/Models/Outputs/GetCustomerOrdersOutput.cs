using System;
using System.Collections.Generic;
using FitoGraph.Api.Domain.Entities;
using FitoGraph.Api.Domain.Models.Utils;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetCustomerOrdersOutput
    {
        public List<OrderItem> list { get; set; }
        public class OrderItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public decimal TotalPayablePrice { get; set; }
            public string Restaurant { get; set; }
        }
    }
}
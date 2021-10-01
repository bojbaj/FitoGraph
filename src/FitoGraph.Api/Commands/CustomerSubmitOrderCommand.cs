using System;
using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class CustomerSubmitOrderCommand : IRequest<ResultWrapper<CustomerSubmitOrderOutput>>
    {
        public string firebaseId { get; set; }
        [Required]
        public TransactionItem Transaction { get; set; }
        [Required]
        public OrderDetailItem[] OrderItems { get; set; }

        public class TransactionItem
        {
            [Required]
            public Guid id { get; set; }
        }

        public class OrderDetailItem
        {
            [Required]
            public int FoodId { get; set; }
            [Required]
            public int Amount { get; set; }
        }
    }
}
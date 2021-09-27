using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class CustomerCreatePaymentSessionCommand : IRequest<ResultWrapper<CustomerCreatePaymentSessionOutput>>
    {
        public string firebaseId { get; set; }
        [Required]
        public string SuccessUrl { get; set; }
        [Required]
        public string CancelUrl { get; set; }
        [Required]
        public OrderDetailItem[] OrderItems { get; set; }
        public class OrderDetailItem
        {
            [Required]
            public int FoodId { get; set; }
            [Required]
            public int Amount { get; set; }
            [Required]
            public long Price { get; set; }
        }
    }
}
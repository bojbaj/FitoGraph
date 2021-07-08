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
            public string id { get; set; }
            public string Object { get; set; }
            public string client_ip { get; set; }
            public string created { get; set; }
            public string email { get; set; }
            public string livemode { get; set; }
            public string type { get; set; }
            public string used { get; set; }
            public CardItem card { get; set; }
            public class CardItem
            {
                public string id { get; set; }
                public string Object { get; set; }
                public string address_city { get; set; }
                public string address_country { get; set; }
                public string address_line1 { get; set; }
                public string address_line1_check { get; set; }
                public string address_line2 { get; set; }
                public string address_state { get; set; }
                public string address_zip { get; set; }
                public string address_zip_check { get; set; }
                public string brand { get; set; }
                public string country { get; set; }
                public string cvc_check { get; set; }
                public string dynamic_last4 { get; set; }
                public string exp_month { get; set; }
                public string exp_year { get; set; }
                public string funding { get; set; }
                public string last4 { get; set; }
                public string name { get; set; }
                public string tokenization_method { get; set; }
            }
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
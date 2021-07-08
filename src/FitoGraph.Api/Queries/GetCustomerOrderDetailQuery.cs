using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetCustomerOrderDetailQuery : IRequest<ResultWrapper<GetCustomerOrderDetailOutput>>
    {
        public string firebaseId { get; set; }
        public int orderId { get; set; }
    }
}
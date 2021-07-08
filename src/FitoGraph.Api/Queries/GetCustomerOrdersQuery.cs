using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetCustomerOrdersQuery : IRequest<ResultWrapper<GetCustomerOrdersOutput>>
    {
        public string firebaseId { get; set; }
    }
}
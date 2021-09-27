using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetCustomerArticlesQuery : IRequest<ResultWrapper<GetCustomerArticlesOutput>>
    {
        public string firebaseId { get; set; }        
    }
}
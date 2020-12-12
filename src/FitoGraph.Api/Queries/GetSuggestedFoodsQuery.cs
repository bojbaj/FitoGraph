using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetSuggestedFoodsQuery : IRequest<ResultWrapper<GetSuggestedFoodsOutput>>
    {
        public string firebaseId { get; set; }
        public int RequiredCalorie { get; set; }
    }
}
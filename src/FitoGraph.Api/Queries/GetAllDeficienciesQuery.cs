using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetAllDeficienciesQuery : IRequest<ResultWrapper<GetAllDeficienciesOutput>>
    {
        public string firebaseId { get; set; }
        public int foodId { get; set; }
    }
}
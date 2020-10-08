using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetRegionCitiesQuery : IRequest<ResultWrapper<GetRegionCitiesOutput>>
    {
        public string userId { get; set; }
        public int TRegionStateId { get; set; }
    }
}
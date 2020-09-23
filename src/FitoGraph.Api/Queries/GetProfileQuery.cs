using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetProfileQuery : IRequest<ResultWrapper<GetProfileOutput>>
    {
        public string firebaseId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetAllBodyTypesQuery : IRequest<ResultWrapper<GetAllBodyTypesOutput>>
    {
        public string idToken { get; set; }
    }
}
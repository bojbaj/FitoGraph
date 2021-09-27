using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Queries
{

    public class GetAllArticlesQuery : IRequest<ResultWrapper<GetAllArticlesOutput>>
    {
        public string firebaseId { get; set; }
    }
}
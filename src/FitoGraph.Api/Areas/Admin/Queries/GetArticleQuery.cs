using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Queries
{

    public class GetArticleQuery : IRequest<ResultWrapper<GetArticleOutput>>
    {
        public string firebaseId { get; set; }
        public int Id { get; set; }
    }
}
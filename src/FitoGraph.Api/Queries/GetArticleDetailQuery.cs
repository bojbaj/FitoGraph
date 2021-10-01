using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetArticleDetailQuery : IRequest<ResultWrapper<GetArticleDetailOutput>>
    {
        public string firebaseId { get; set; }
        public int articleId { get; set; }
    }
}
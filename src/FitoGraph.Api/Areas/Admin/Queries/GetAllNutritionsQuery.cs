using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Queries
{

    public class GetAllNutritionsQuery : IRequest<ResultWrapper<GetAllNutritionsOutput>>
    {
        public string query { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
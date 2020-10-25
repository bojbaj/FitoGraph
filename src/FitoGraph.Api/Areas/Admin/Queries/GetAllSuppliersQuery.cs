using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Queries
{

    public class GetAllSuppliersQuery : IRequest<ResultWrapper<GetAllSuppliersOutput>>
    {
        public string firebaseId { get; set; }
    }
}
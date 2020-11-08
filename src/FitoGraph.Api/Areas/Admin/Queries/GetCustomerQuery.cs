using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Queries
{

    public class GetCustomerQuery : IRequest<ResultWrapper<GetCustomerOutput>>
    {
        public int Id { get; set; }
    }
}
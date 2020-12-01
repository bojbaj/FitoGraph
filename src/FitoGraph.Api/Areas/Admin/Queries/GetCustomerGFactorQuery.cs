using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Queries
{

    public class GetCustomerGFactorQuery : IRequest<ResultWrapper<GetCustomerGFactorOutput>>
    {
        public int Id { get; set; }
    }
}
using FitoGraph.Api.Areas.Supplier.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Supplier.Queries
{

    public class GetSupplierFoodsQuery : IRequest<ResultWrapper<GetSupplierFoodsOutput>>
    {
        public string firebaseId { get; set; }
    }
}
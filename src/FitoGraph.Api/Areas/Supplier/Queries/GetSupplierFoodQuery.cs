using FitoGraph.Api.Areas.Supplier.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Supplier.Queries
{

    public class GetSupplierFoodQuery : IRequest<ResultWrapper<GetSupplierFoodOutput>>
    {
        public string firebaseId { get; set; }
        public int FoodId { get; set; }
    }
}
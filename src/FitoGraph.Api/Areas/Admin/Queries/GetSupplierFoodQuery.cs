using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Queries
{

    public class GetSupplierFoodQuery : IRequest<ResultWrapper<GetSupplierFoodOutput>>
    {
        public string firebaseId { get; set; }
        public int SupplierId { get; set; }
        public int FoodId { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Areas.Supplier.Queries
{
    public class GetSupplierOrderDetailQuery : IRequest<ResultWrapper<GetSupplierOrderDetailOutput>>
    {
        public string firebaseId { get; set; }
        public int orderId { get; set; }
    }
}
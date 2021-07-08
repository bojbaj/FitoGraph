using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetSupplierOrdersQuery : IRequest<ResultWrapper<GetSupplierOrdersOutput>>
    {
        public string firebaseId { get; set; }
    }
}
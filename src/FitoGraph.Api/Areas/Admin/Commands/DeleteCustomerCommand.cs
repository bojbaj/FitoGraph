using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Commands
{
    public class DeleteCustomerCommand : IRequest<ResultWrapper<DeleteCustomerOutput>>
    {
        public string FireBaseId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "UserId is required")]
        public int UserId { get; set; }
    }
}
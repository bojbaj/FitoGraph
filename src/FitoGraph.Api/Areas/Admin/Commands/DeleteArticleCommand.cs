using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Commands
{
    public class DeleteArticleCommand : IRequest<ResultWrapper<DeleteArticleOutput>>
    {
        public string FireBaseId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id is required")]
        public int Id { get; set; }
    }
}
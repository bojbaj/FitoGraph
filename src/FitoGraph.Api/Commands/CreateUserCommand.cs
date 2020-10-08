using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class CreateUserCommand : IRequest<ResultWrapper<CreateUserOutput>>
    {
        [Required]
        public string FireBaseId { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
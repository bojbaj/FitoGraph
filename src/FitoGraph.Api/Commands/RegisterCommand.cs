using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class RegisterCommand : IRequest<ResultWrapper<RegisterOutput>>
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }        
        public string Role { get; set; }        
    }
}
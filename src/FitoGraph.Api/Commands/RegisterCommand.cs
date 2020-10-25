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
        [Required]
        [Range(1, 2, ErrorMessage = "Please select your gender")]
        public int Gender { get; set; }
        public Infrastructure.AppEnums.RoleEnum Role { get; set; }        
    }
}
using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class LoginCommand : IRequest<ResultWrapper<LoginOutput>>
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }        
        public string Role { get; set; }        
    }
}
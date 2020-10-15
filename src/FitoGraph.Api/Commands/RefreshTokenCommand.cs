using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class RefreshTokenCommand : IRequest<ResultWrapper<RefreshTokenOutput>>
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
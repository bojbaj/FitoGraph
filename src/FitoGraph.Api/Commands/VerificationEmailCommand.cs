using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class SendVerificationEmailCommand : IRequest<ResultWrapper<SendVerificationEmailOutput>>
    {
        [Required]
        public string idToken { get; set; }
    }
}
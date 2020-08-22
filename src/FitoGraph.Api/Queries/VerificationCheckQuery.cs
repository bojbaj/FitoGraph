using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class VerificationCheckQuery : IRequest<ResultWrapper<VerificationCheckOutput>>
    {
        [Required]
        public string idToken { get; set; }
    }
}
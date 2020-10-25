using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class DeleteFromFirebaseCommand : IRequest<ResultWrapper<DeleteFromFirebaseOutput>>
    {
        [Required]
        public string IdToken { get; set; }
    }
}
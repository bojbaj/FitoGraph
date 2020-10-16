using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class UpdateProfileActivitiesCommand : IRequest<ResultWrapper<UpdateProfileActivitiesOutput>>
    {
        public string firebaseId { get; set; }
        [Required]
        public List<int> Activities { get; set; }
    }
}
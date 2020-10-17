using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class UpdateProfileHealthConditionsCommand : IRequest<ResultWrapper<UpdateProfileHealthConditionsOutput>>
    {
        public string firebaseId { get; set; }
        [Required]
        public List<int> Diets { get; set; }
        [Required]
        public List<int> Allergies { get; set; }
        [Required]
        public List<int> Deficiencies { get; set; }
        [Required]
        public List<int> NutritionConditions { get; set; }
    }
}
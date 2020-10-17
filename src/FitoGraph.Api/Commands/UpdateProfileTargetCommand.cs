using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class UpdateProfileTargetCommand : IRequest<ResultWrapper<UpdateProfileTargetOutput>>
    {
        public string firebaseId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Activity level isn't valid")]
        public int ActivityLevelId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Goal isn't valid")]
        public int GoalId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Weight isn't valid")]
        public int TargetWeight { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Weekly goal isn't valid")]
        public int WeeklyGoalId { get; set; }
    }
}
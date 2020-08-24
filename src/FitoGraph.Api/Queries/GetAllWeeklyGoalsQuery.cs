using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetAllWeeklyGoalsQuery : IRequest<ResultWrapper<GetAllWeeklyGoalsOutput>>
    {
        public string idToken { get; set; }
        public int TGoalId { get; set; }
    }
}
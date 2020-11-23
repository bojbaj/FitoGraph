using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Queries
{

    public class GetAllNutritionUnitsQuery : IRequest<ResultWrapper<GetAllNutritionUnitsOutput>>
    {
        public string firebaseId { get; set; }
        public int nutritionId { get; set; }
    }
}
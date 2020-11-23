using System.Collections.Generic;
using FitoGraph.Api.Domain.Models;

namespace FitoGraph.Api.Areas.Admin.Outputs
{
    public class GetAllNutritionUnitsOutput
    {
        public List<PublicListItem> list { get; set; }
    }
}
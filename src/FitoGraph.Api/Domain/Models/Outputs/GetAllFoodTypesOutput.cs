using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetAllFoodTypesOutput
    {
        public List<PublicListItem> list { get; set; }
    }
}
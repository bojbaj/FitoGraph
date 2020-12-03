using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetSuggestedFoodsOutput
    {
        public List<PublicListItem> list { get; set; }
    }
}
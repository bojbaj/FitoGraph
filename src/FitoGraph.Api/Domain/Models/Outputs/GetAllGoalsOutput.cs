using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetAllGoalsOutput
    {
        public List<PublicListItem> list { get; set; }
    }
}
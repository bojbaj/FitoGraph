using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetAllWeeklyGoalsOutput
    {
        public List<PublicListItem> list { get; set; }
    }
}
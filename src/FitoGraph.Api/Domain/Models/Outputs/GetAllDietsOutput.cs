using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetAllDietsOutput
    {
        public List<PublicListItem> list { get; set; }
    }
}
using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetAllAllergiesOutput
    {
        public List<PublicListItem> list { get; set; }
    }
}
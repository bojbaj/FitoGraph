using System.Collections.Generic;
using FitoGraph.Api.Domain.Models;

namespace FitoGraph.Api.Areas.Admin.Outputs
{
    public class GetAllCustomersOutput
    {
        public List<PublicListItem> list { get; set; }
    }
}
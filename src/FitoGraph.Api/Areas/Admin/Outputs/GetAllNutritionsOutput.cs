using System.Collections.Generic;
using FitoGraph.Api.Domain.Models;

namespace FitoGraph.Api.Areas.Admin.Outputs
{
    public class GetAllNutritionsOutput
    {
        public List<PublicListItem> list { get; set; }
        public int totalItems { get; set; }
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
        public int totalPages
        {
            get
            {
                return (totalItems / pageSize) + 1;
            }
        }
    }
}
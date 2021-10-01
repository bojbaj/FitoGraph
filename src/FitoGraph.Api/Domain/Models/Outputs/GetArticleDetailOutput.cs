using System.Collections.Generic;
using FitoGraph.Api.Domain.Entities;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetArticleDetailOutput
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public List<string> Sports { get; set; }
    }
}
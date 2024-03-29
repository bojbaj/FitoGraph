using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetCustomerArticlesOutput
    {
        public List<ArticleItem> list { get; set; }
        public class ArticleItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Summary { get; set; }
            public string Image { get; set; }
        }
    }
}
using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TArticleSport : BaseEntity
    {
        public int TArticleId { get; set; }
        public int TSportId { get; set; }
        public TArticle TArticle { get; set; }
        public TSport TSport { get; set; }
    }
}
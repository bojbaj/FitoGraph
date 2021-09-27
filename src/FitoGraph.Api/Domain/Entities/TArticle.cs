using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitoGraph.Api.Domain.Entities
{
    public class TArticle : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public ICollection<TArticleSport> TArticleSports { get; set; }
    }
}
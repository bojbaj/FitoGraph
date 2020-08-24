using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TBodyType : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<TUser> TUsers { get; set; }
    }
}
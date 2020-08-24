using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TActivityLevel : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Note { get; set; }
        public double PALForMale { get; set; }
        public double PALForFeMale { get; set; }
        public double Protein { get; set; }
        public double Carb { get; set; }
        public ICollection<TUser> TUsers { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitoGraph.Api.Domain.Entities
{
    public class TActivityLevel : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Note { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal PALForMale { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal PALForFeMale { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Protein { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Carb { get; set; }
        public ICollection<TUser> TUsers { get; set; }
    }
}
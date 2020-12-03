using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitoGraph.Api.Domain.Entities
{
    public class TReferenceInRange : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public int Gender { get; set; }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
        public int? TReferenceId { get; set; }
        public TReference TReference { get; set; }        
    }
}
using System;

namespace FitoGraph.Api.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public bool Enabled { get; set; }
    }
}
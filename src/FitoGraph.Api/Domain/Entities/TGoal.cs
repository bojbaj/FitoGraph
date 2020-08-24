using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TGoal : BaseEntity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public ICollection<TUser> TUsers { get; set; }
        public ICollection<TWeeklyGoal> TWeeklyGoals { get; set; }
    }
}
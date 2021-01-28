using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Entities
{
    public class TWeeklyGoal : BaseEntity
    {
        public int TGoalId { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
        public int CaloryRequirePercent { get; set; }
        public TGoal TGoal { get; set; }
        public ICollection<TUser> TUsers { get; set; }
    }
}
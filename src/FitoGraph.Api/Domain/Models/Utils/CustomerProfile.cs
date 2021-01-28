using FitoGraph.Api.Domain.Models.Outputs;

namespace FitoGraph.Api.Domain.Models.Utils
{
    public class CustomerProfile
    {
        public string FireBaseId { get; set; }
        public bool Enabled { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int BirthYear { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public int RegionCountryId { get; set; }
        public int RegionStateId { get; set; }
        public int RegionCityId { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Waist { get; set; }
        public decimal Hips { get; set; }
        public decimal Forearms { get; set; }
        public decimal Fat { get; set; }
        public decimal TargetWeight { get; set; }
        public decimal ActivityLevelPalForMale { get; set; }
        public decimal ActivityLevelPalForFemale { get; set; }
        public decimal ActivityLevelCarb { get; set; }
        public decimal ActivityLevelProtein { get; set; }
        public int ActivityLevelId { get; set; }
        public int GoalId { get; set; }
        public int WeeklyGoalId { get; set; }
        public decimal WeeklyGoalCaloryPercent { get; set; }
        public BodyTypeOutput BodyType { get; set; }
        public int Gender { get; set; }
    }
}
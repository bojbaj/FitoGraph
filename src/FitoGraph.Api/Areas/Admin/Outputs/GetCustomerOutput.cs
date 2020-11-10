using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Domain.Models.Utils;

namespace FitoGraph.Api.Areas.Admin.Outputs
{
    public class GetCustomerOutput : CustomerProfileCalculated
    {
        public string RegionCountryName { get; set; }
        public string RegionStateName { get; set; }
        public string RegionCityName { get; set; }
    }
}
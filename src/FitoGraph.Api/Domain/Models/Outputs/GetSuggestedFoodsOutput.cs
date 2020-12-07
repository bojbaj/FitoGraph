using System.Collections.Generic;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetSuggestedFoodsOutput
    {
        public List<FoodItem> list { get; set; }
        public class FoodItem
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Image { get; set; }
            public List<string> Tags { get; set; }
            public decimal Price { get; set; }
            public int MatchRate { get; set; }
            public string Restaurant { get; set; }
        }
    }
}
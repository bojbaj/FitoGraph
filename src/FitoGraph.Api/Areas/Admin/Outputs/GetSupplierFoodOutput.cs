using System.Collections.Generic;

namespace FitoGraph.Api.Areas.Admin.Outputs
{
    public class GetSupplierFoodOutput
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int FoodTypeId { get; set; }
        public string FoodTypeName { get; set; }
        public List<FoodNutrition> FoodNutritions { get; set; }
        public class FoodNutrition
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int UnitId { get; set; }
            public string UnitName { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
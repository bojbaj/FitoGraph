using System.Collections.Generic;
using FitoGraph.Api.Domain.Models;

namespace FitoGraph.Api.Areas.Supplier.Outputs
{
    public class GetSupplierFoodOutput
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Tags { get; set; }
        public decimal Price { get; set; }
        public int FoodTypeId { get; set; }
        public string FoodTypeName { get; set; }
        public List<PublicListItem> Allergies { get; set; }
        public List<PublicListItem> Diets { get; set; }
        public List<PublicListItem> Deficiencies { get; set; }
        public List<PublicListItem> NutritionConditions { get; set; }

        public List<FoodNutrition> FoodNutritions { get; set; }
        public class FoodNutrition
        {
            public int NutritionId { get; set; }
            public string NutritionName { get; set; }
            public int UnitId { get; set; }
            public string UnitName { get; set; }
            public decimal Amount { get; set; }
        }
    }
}
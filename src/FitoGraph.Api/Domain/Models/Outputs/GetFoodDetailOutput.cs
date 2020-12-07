using System.Collections.Generic;
using FitoGraph.Api.Domain.Entities;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class GetFoodDetailOutput
    {
        public int Id { get; set; }
        public bool Enabled { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public List<string> Tags { get; set; }
        public int FoodTypeId { get; set; }
        public string FoodTypeName { get; set; }
        public List<FoodNutrition> FoodNutritions { get; set; }
        public VitaminMinreal VitaminMinreals { get; set; }       
        public class FoodNutrition
        {
            public int NutritionId { get; set; }
            public string NutritionName { get; set; }
            public int UnitId { get; set; }
            public string UnitName { get; set; }
            public decimal Amount { get; set; }
        }
        public class VitaminMinreal
        {
            public decimal Energy { get; set; }
            public decimal Protein { get; set; }
            public decimal carbohydrate { get; set; }
            public decimal Fat { get; set; }
            public decimal Ash { get; set; }
            public decimal Dietary_Fibre { get; set; }
            public decimal Fructose { get; set; }
            public decimal Glucose { get; set; }
            public decimal Sucrose { get; set; }
            public decimal Lactose { get; set; }
            public decimal Total_Sugars { get; set; }
            public decimal Starch { get; set; }
            public decimal Calcium { get; set; }
            public decimal Chloride { get; set; }
            public decimal Copper { get; set; }
            public decimal Fluoride { get; set; }
            public decimal Iodine { get; set; }
            public decimal Iron { get; set; }
            public decimal Magnesium { get; set; }
            public decimal Manganese { get; set; }
            public decimal Phosphorus { get; set; }
            public decimal Potassium { get; set; }
            public decimal Selenium { get; set; }
            public decimal Sodium { get; set; }
            public decimal Sulphur { get; set; }
            public decimal Tin { get; set; }
            public decimal Zinc { get; set; }
            public decimal Alpha_Carotene { get; set; }
            public decimal Beta_Carotene { get; set; }
            public decimal Cryptoxanthin { get; set; }
            public decimal Vitamin_A { get; set; }
            public decimal Lutein { get; set; }
            public decimal Lycopene { get; set; }
            public decimal Thiamin_B1 { get; set; }
            public decimal Riboflavin_B2 { get; set; }
            public decimal Niacin_B3 { get; set; }
            public decimal Pantothenic_Acid_B5 { get; set; }
            public decimal Vitamin_B6 { get; set; }
            public decimal Biotin_B7 { get; set; }
            public decimal Vitamin_B12 { get; set; }
            public decimal Folate { get; set; }
            public decimal Folic_Acid { get; set; }
            public decimal Vitamin_C { get; set; }
            public decimal Vitamin_D { get; set; }
            public decimal Molybdenum { get; set; }
            public decimal Chromium { get; set; }
            public decimal Vitamin_E { get; set; }
            public decimal Total_Saturated_Fatty_Acids { get; set; }
            public decimal Total_Monounsaturated_Fatty_Acids { get; set; }
            public decimal Total_Polyunsaturated_Fatty_Acids { get; set; }
            public decimal Total_Long_Chain_Omega_3_Fatty_Acids { get; set; }
            public decimal Total_Trans_Fatty_Acids { get; set; }
            public decimal Caffeine { get; set; }
            public decimal Cholesterol { get; set; }
        }
    }
}
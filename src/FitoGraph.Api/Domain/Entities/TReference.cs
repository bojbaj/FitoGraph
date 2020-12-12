using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Domain.Entities
{
    public class TReference : BaseEntity
    {
        public int RecordId { get; set; }
        public ReferenceRecordTypeEnum RecordType { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Calorie { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Energy { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Protein { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal carbohydrate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Fat { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Ash { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Dietary_Fibre { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Fructose { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Glucose { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Sucrose { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Lactose { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Sugars { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Starch { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Calcium { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Chloride { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Copper { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Fluoride { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Iodine { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Iron { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Magnesium { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Manganese { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Phosphorus { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Potassium { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Selenium { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Sodium { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Sulphur { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Tin { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Zinc { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Alpha_Carotene { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Beta_Carotene { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Cryptoxanthin { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Vitamin_A { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Lutein { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Lycopene { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Thiamin_B1 { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Riboflavin_B2 { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Niacin_B3 { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Pantothenic_Acid_B5 { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Vitamin_B6 { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Biotin_B7 { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Vitamin_B12 { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Folate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Folic_Acid { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Vitamin_C { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Vitamin_D { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Molybdenum { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Chromium { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Vitamin_E { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Saturated_Fatty_Acids { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Monounsaturated_Fatty_Acids { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Polyunsaturated_Fatty_Acids { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Long_Chain_Omega_3_Fatty_Acids { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Total_Trans_Fatty_Acids { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Caffeine { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Cholesterol { get; set; }
        public ICollection<TNutrition> TNutritions { get; set; }
        public ICollection<TFood> TFoods { get; set; }
        public ICollection<TFoodNutrition> TFoodNutritions { get; set; }
        public ICollection<TUser> TUsers { get; set; }
        public ICollection<TReferenceInRange> TReferenceInRange { get; set; }
    }
}
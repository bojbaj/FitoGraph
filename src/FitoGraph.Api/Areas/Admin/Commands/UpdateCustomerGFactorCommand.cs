using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Commands
{
    public class UpdateCustomerGFactorCommand : IRequest<ResultWrapper<UpdateCustomerGFactorOutput>>
    {
        [Required]        
        [Range(1, int.MaxValue, ErrorMessage = "UserId is missing!")]
        public int Id { get; set; }        
        public decimal DietaryFibre { get; set; }
        public decimal Thiamin_B1 { get; set; }
        public decimal Riboflavin_B2 { get; set; }
        public decimal Niacin_B3 { get; set; }
        public decimal Vitamin_B6 { get; set; }
        public decimal Vitamin_B12 { get; set; }
        public decimal Folate { get; set; }
        public decimal Pantothenic_acid_B5 { get; set; }
        public decimal Biotin_B7 { get; set; }
        public decimal Vitamin_A { get; set; }
        public decimal Vitamin_C { get; set; }
        public decimal Vitamin_D { get; set; }
        public decimal Vitamin_E { get; set; }
        public decimal Calcium_Ca { get; set; }
        public decimal Phosphorus_P { get; set; }
        public decimal Zinc_Zn { get; set; }
        public decimal Iron_Fe { get; set; }
        public decimal Magnesium_Mg { get; set; }
        public decimal Iodine_I { get; set; }
        public decimal Selenium_Se { get; set; }
        public decimal Molybdenum_Mo { get; set; }
        public decimal Copper_Cu { get; set; }
        public decimal Chromium_Cr { get; set; }
        public decimal Manganese_Mn { get; set; }
        public decimal Fluoride_F { get; set; }
        public decimal Sodium_Na { get; set; }
        public decimal Potassium_K { get; set; }
    }
}
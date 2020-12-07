using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Commands
{
    public class UpdateSupplierFoodCommand : IRequest<ResultWrapper<UpdateSupplierFoodOutput>>
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please specify food")]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public bool Enabled { get; set; }
        public string Image { get; set; }
        public string Tags { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select food type")]
        public int FoodTypeId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please specify supplier")]
        public int UserId { get; set; }
        [Required]
        public List<int> Diets { get; set; }
        [Required]
        public List<int> Allergies { get; set; }
        [Required]
        public List<int> Deficiencies { get; set; }
        [Required]
        public List<int> NutritionConditions { get; set; }
        [Required]
        public List<FoodNutrition> FoodNutritions { get; set; }
        public class FoodNutrition
        {
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Nutritions data is invalid [id]")]
            public int Id { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Nutritions data is invalid [UnitId]")]
            public int UnitId { get; set; }
            [Required]
            [Range(1, int.MaxValue, ErrorMessage = "Nutritions data is invalid [Amount]")]
            public decimal Amount { get; set; }
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Domain.Entities
{
    public class TFoodNutrition : BaseEntity
    {
        public int TFoodId { get; set; }
        public TFood TFood { get; set; }
        public int TNutritionId { get; set; }
        public TNutrition TNutrition { get; set; }
        public int TNutritionUnitId { get; set; }
        public TNutritionUnit TNutritionUnit { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        public int TReferenceId { get; set; }
        public TReference TReference { get; set; }
    }
}
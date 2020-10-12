using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class UpdateProfileBodyInfoCommand : IRequest<ResultWrapper<UpdateProfileBodyInfoOutput>>
    {
        public string firebaseId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Body Type is required")]
        public int BodyTypeId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Weight is required")]
        public decimal Weight { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Heigth is required")]
        public decimal Height { get; set; }
        public decimal Waist { get; set; }
        public decimal Hips { get; set; }
        public decimal Forearms { get; set; }
        public decimal Fat { get; set; }
    }
}
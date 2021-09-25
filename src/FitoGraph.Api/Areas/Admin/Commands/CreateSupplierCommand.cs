using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Commands
{
    public class CreateSupplierCommand : IRequest<ResultWrapper<CreateSupplierOutput>>
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Range(1, 2, ErrorMessage = "Please select your gender")]
        public int Gender { get; set; }
        public Infrastructure.AppEnums.RoleEnum Role { get; set; }
        public string FireBaseId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "please select city")]
        public int RegionCityId { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }
        public string ShareAccount { get; set; }
        [Range(1, 99, ErrorMessage = "Please enter a valid share percent between 1 and 99")]
        public decimal SharePercent { get; set; }
        public decimal Lat { get; set; }        
        public decimal Lng { get; set; }
    }
}
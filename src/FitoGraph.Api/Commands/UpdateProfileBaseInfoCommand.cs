using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class UpdateProfileBaseInfoCommand : IRequest<ResultWrapper<UpdateProfileBaseInfoOutput>>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string firebaseId { get; set; }
        [Required]
        [Range(1900, 2100, ErrorMessage = "Birth year isn't valid")]
        public int BirthYear { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Selected city isn't valid")]
        public int CityId { get; set; }

    }
}
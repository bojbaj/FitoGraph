﻿using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Areas.Admin.Commands
{
    public class UpdateSupplierCommand : IRequest<ResultWrapper<UpdateSupplierOutput>>
    {
        [Required]
        public int  Id { get; set; }
        [Required]
        [Range(1, 2, ErrorMessage = "Please select your gender")]
        public int Gender { get; set; }
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
    }
}
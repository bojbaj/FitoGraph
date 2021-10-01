using System;
using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Commands
{
    public class CustomerSubmitOrderCommand : IRequest<ResultWrapper<CustomerSubmitOrderOutput>>
    {
        public string firebaseId { get; set; }
        [Required]
        public Guid UID { get; set; }
    }
}
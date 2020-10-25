using System;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Events
{
    public class SupplierRegisterEvent : INotification
    {
        public RegisterCommand Request { get; set; }
        public RegisterOutput Response { get; set; }
    }
}
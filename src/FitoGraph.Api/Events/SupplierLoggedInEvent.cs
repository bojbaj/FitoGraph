using System;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Events
{
    public class SupplierLoggedInEvent : INotification
    {
        public LoginCommand Request { get; set; }
        public LoginOutput Response { get; set; }
    }
}
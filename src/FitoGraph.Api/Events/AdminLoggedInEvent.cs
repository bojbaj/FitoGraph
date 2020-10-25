using System;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Events
{
    public class AdminLoggedInEvent : INotification
    {
        public LoginCommand Request { get; set; }
        public LoginOutput Response { get; set; }
    }
}
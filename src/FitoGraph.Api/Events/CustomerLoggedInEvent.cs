using System;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models.Auth;
using MediatR;

namespace FitoGraph.Api.Events
{
    public class CustomerLoggedInEvent : INotification
    {
        public LoginCommand Request { get; set; }
        public LoginOutput Response { get; set; }
    }
}
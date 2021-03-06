﻿using System;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Events
{
    public class SendVerificationEmailEvent : INotification
    {
        public SendVerificationEmailCommand Request { get; set; }
        public SendVerificationEmailOutput Response { get; set; }
    }
}
using System;
using System.Collections.Generic;
using FitoGraph.Api.Domain.Entities;

namespace FitoGraph.Api.Domain.Models.Outputs
{
    public class CustomerCreatePaymentSessionOutput
    {
        public string SessionId { get; set; }
        public string SessionUrl { get; set; }
    }
}
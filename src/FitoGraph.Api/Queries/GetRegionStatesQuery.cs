﻿using System.ComponentModel.DataAnnotations;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using MediatR;

namespace FitoGraph.Api.Queries
{
    public class GetRegionStatesQuery : IRequest<ResultWrapper<GetRegionStatesOutput>>
    {
        public string idToken { get; set; }
        public int TRegionCountryId { get; set; }
    }
}
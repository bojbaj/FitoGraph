using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using FitoGraph.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FitoGraph.Api.Commands.Handler
{
    public class GetAllRegionCountriesQueryHandler : IRequestHandler<GetAllRegionCountriesQuery, ResultWrapper<GetAllRegionCountriesOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetAllRegionCountriesQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetAllRegionCountriesOutput>> Handle(GetAllRegionCountriesQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetAllRegionCountriesOutput> result = new ResultWrapper<GetAllRegionCountriesOutput>();

            var tDataList = await _dbContext.TRegionCountry
                .Include(x => x.TRegionStates).ThenInclude(x => x.TRegionCities)
                .ThenInclude(x => x.TUsers).ToListAsync();
            var list = tDataList.Select(x => new PublicListItem()
            {
                Enabled = x.Enabled,
                Selected = x.TRegionStates.SelectMany(z => z.TRegionCities).SelectMany(z => z.TUsers).Any(z => z.FireBaseId == request.firebaseId),
                Text = x.Title,
                Value = x.Id.ToString(),
                Image = x.Image.JoinWithCDNAddress()
            })
            .ToList();
            result.Status = true;
            result.Result = new GetAllRegionCountriesOutput()
            {
                list = list
            };

            return result;
        }
    }
}
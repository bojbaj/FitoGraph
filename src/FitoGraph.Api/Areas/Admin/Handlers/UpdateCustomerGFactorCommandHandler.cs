using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FitoGraph.Api.Areas.Admin.Commands;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Entities;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class UpdateCustomerGFactorCommandHandler : IRequestHandler<UpdateCustomerGFactorCommand, ResultWrapper<UpdateCustomerGFactorOutput>>
    {
        private readonly AppDbContext _dbContext;
        public UpdateCustomerGFactorCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<UpdateCustomerGFactorOutput>> Handle(UpdateCustomerGFactorCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<UpdateCustomerGFactorOutput> result = new ResultWrapper<UpdateCustomerGFactorOutput>();

            TUser tUser = await _dbContext.TUser
                .Include(x => x.TReference)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (tUser == null)
            {
                result.Status = false;
                result.Message = "This user doesn't exists";
                return result;
            }

            TReference tUserReference = tUser.TReference;
            if (tUserReference == null)
            {
                result.Status = false;
                result.Message = "This user record has some problems!";
                return result;
            }

            tUserReference.Biotin_B7 = request.Biotin_B7;
            tUserReference.Calcium = request.Calcium_Ca;
            tUserReference.Chromium = request.Chromium_Cr;
            tUserReference.Copper = request.Copper_Cu;
            tUserReference.Dietary_Fibre = request.DietaryFibre;
            tUserReference.Fluoride = request.Fluoride_F;
            tUserReference.Folate = request.Folate;
            tUserReference.Iodine = request.Iodine_I;
            tUserReference.Iron = request.Iron_Fe;
            tUserReference.Magnesium = request.Magnesium_Mg;
            tUserReference.Manganese = request.Manganese_Mn;
            tUserReference.Molybdenum = request.Molybdenum_Mo;
            tUserReference.Niacin_B3 = request.Niacin_B3;
            tUserReference.Pantothenic_Acid_B5 = request.Pantothenic_acid_B5;
            tUserReference.Phosphorus = request.Phosphorus_P;
            tUserReference.Potassium = request.Potassium_K;
            tUserReference.Riboflavin_B2 = request.Riboflavin_B2;
            tUserReference.Selenium = request.Selenium_Se;
            tUserReference.Sodium = request.Sodium_Na;
            tUserReference.Thiamin_B1 = request.Thiamin_B1;
            tUserReference.Vitamin_A = request.Vitamin_A;
            tUserReference.Vitamin_B12 = request.Vitamin_B12;
            tUserReference.Vitamin_B6 = request.Vitamin_B6;
            tUserReference.Vitamin_C = request.Vitamin_C;
            tUserReference.Vitamin_D = request.Vitamin_D;
            tUserReference.Vitamin_E = request.Vitamin_E;
            tUserReference.Zinc = request.Zinc_Zn;
            _dbContext.TReference.Update(tUserReference);
            _dbContext.SaveChanges();

            result.Status = true;
            result.Result = new UpdateCustomerGFactorOutput()
            {
                Id = tUser.Id
            };
            return result;
        }
    }
}
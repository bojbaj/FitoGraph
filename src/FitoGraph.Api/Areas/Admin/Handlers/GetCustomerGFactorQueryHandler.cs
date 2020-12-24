using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Areas.Admin.Queries;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Entities;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class GetCustomerGFactorQueryHandler : IRequestHandler<GetCustomerGFactorQuery, ResultWrapper<GetCustomerGFactorOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetCustomerGFactorQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetCustomerGFactorOutput>> Handle(GetCustomerGFactorQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetCustomerGFactorOutput> result = new ResultWrapper<GetCustomerGFactorOutput>();

            TUser tUser = await _dbContext.TUser
                .Include(x => x.TReference)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (tUser == null)
            {
                result.Status = false;
                result.Message = "this user doesn't exists";
                return result;
            }

            TReference tUserReference = tUser.TReference;

            if (tUserReference == null)
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew))
                {
                    tUserReference = new TReference()
                    {
                        Enabled = true,
                        RecordType = ReferenceRecordTypeEnum.GFACTOR,
                        RecordId = tUser.Id,
                        Biotin_B7 = 1,
                        Calcium = 1,
                        Chromium = 1,
                        Copper = 1,
                        Dietary_Fibre = 1,
                        Fluoride = 1,
                        Folate = 1,
                        Iodine = 1,
                        Iron = 1,
                        Magnesium = 1,
                        Manganese = 1,
                        Molybdenum = 1,
                        Niacin_B3 = 1,
                        Pantothenic_Acid_B5 = 1,
                        Phosphorus = 1,
                        Potassium = 1,
                        Riboflavin_B2 = 1,
                        Selenium = 1,
                        Sodium = 1,
                        Thiamin_B1 = 1,
                        Vitamin_A = 1,
                        Vitamin_B12 = 1,
                        Vitamin_B6 = 1,
                        Vitamin_C = 1,
                        Vitamin_D = 1,
                        Vitamin_E = 1,
                        Zinc = 1
                    };
                    _dbContext.TReference.Add(tUserReference);
                    _dbContext.SaveChanges();
                    tUser.TReferenceId = tUserReference.Id;
                    _dbContext.TUser.Update(tUser);
                    _dbContext.SaveChanges();
                    transaction.Complete();
                }
            }

            result.Status = true;
            result.Result = new GetCustomerGFactorOutput()
            {
                Biotin_B7 = tUserReference.Biotin_B7,
                Calcium_Ca = tUserReference.Calcium,
                Chromium_Cr = tUserReference.Chromium,
                Copper_Cu = tUserReference.Copper,
                DietaryFibre = tUserReference.Dietary_Fibre,
                Fluoride_F = tUserReference.Fluoride,
                Folate = tUserReference.Folate,
                Iodine_I = tUserReference.Iodine,
                Iron_Fe = tUserReference.Iron,
                Magnesium_Mg = tUserReference.Magnesium,
                Manganese_Mn = tUserReference.Manganese,
                Molybdenum_Mo = tUserReference.Molybdenum,
                Niacin_B3 = tUserReference.Niacin_B3,
                Pantothenic_acid_B5 = tUserReference.Pantothenic_Acid_B5,
                Phosphorus_P = tUserReference.Phosphorus,
                Potassium_K = tUserReference.Potassium,
                Riboflavin_B2 = tUserReference.Riboflavin_B2,
                Selenium_Se = tUserReference.Selenium,
                Sodium_Na = tUserReference.Sodium,
                Thiamin_B1 = tUserReference.Thiamin_B1,
                Vitamin_A = tUserReference.Vitamin_A,
                Vitamin_B12 = tUserReference.Vitamin_B12,
                Vitamin_B6 = tUserReference.Vitamin_B6,
                Vitamin_C = tUserReference.Vitamin_C,
                Vitamin_D = tUserReference.Vitamin_D,
                Vitamin_E = tUserReference.Vitamin_E,
                Zinc_Zn = tUserReference.Zinc
            };
            return result;
        }
    }
}
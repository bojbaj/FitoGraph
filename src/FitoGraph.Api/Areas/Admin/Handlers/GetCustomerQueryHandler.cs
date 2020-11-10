using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

namespace FitoGraph.Api.Areas.Supplier.Handlers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, ResultWrapper<GetCustomerOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetCustomerQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetCustomerOutput>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetCustomerOutput> result = new ResultWrapper<GetCustomerOutput>();

            TUser tUser = await _dbContext.TUser
                .Include(x => x.TBodyType)
                .Include(x => x.TRegionCity).ThenInclude(x => x.TRegionState).ThenInclude(x => x.TRegionCountry)
                .Include(x => x.TActivityLevel)
                .Include(x => x.TWeeklyGoal)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            result.Status = true;
            result.Result = new GetCustomerOutput()
            {
                Email = tUser.Email,
                FireBaseId = tUser.FireBaseId,
                Enabled = tUser.Enabled,
                FirstName = tUser.FirstName,
                LastName = tUser.LastName,
                BirthYear = tUser.BirthYear,
                Phone = tUser.Phone,
                Address = tUser.Address,
                PostalCode = tUser.PostalCode,
                RegionCityId = tUser.TRegionCityId.toInt(0),
                RegionStateId = tUser.TRegionCity?.TRegionStateId.toInt(0) ?? 0,
                RegionCountryId = tUser.TRegionCity?.TRegionState?.TRegionCountryId.toInt(0) ?? 0,
                RegionCityName = tUser.TRegionCity?.Title ?? string.Empty,
                RegionStateName = tUser.TRegionCity?.TRegionState?.Title ?? string.Empty,
                RegionCountryName = tUser.TRegionCity?.TRegionState?.TRegionCountry?.Title ?? string.Empty,
                Weight = tUser.Weight,
                Height = tUser.Height,
                Waist = tUser.Waist,
                Hips = tUser.Hips,
                Forearms = tUser.Forearms,
                Fat = tUser.Fat,
                BodyType = tUser.TBodyType == null ? new BodyTypeOutput() : new BodyTypeOutput()
                {
                    Id = tUser.TBodyType.Id,
                    Title = tUser.TBodyType.Title,
                    Image = tUser.TBodyType.Image
                },
                ActivityLevelPalForMale = tUser.TActivityLevel?.PALForMale ?? 0,
                ActivityLevelPalForFemale = tUser.TActivityLevel?.PALForFeMale ?? 0,
                ActivityLevelCarb = tUser.TActivityLevel?.Carb ?? 0,
                ActivityLevelProtein = tUser.TActivityLevel?.Protein ?? 0,
                Gender = tUser.Gender,
                TargetWeight = tUser.TargetWeight,
                WeeklyGoalId = tUser.TWeeklyGoalId ?? 0,
                GoalId = tUser.TWeeklyGoal?.TGoalId ?? 0,
                ActivityLevelId = tUser.TActivityLevelId ?? 0
            };
            result.Result.BodyType.Image = result.Result.BodyType.Image.JoinWithCDNAddress();
            return result;
        }
    }
}
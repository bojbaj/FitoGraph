using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Areas.Admin.Queries;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Helpers.FireBase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, ResultWrapper<GetSupplierOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetSupplierQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetSupplierOutput>> Handle(GetSupplierQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetSupplierOutput> result = new ResultWrapper<GetSupplierOutput>();

            var tData = await _dbContext.TUser
                .Include(x => x.TRegionCity)
                .ThenInclude(x => x.TRegionState)
                .ThenInclude(x => x.TRegionCountry)
                .FirstOrDefaultAsync(x => x.Role == Infrastructure.AppEnums.RoleEnum.Supplier && x.Id == request.Id);

            result.Status = true;
            result.Result = new GetSupplierOutput()
            {
                Id = tData.Id,
                Email = tData.Email,
                Address = tData.Address,
                FireBaseId = tData.FireBaseId,
                FirstName = tData.FirstName,
                LastName = tData.LastName,
                Gender = tData.Gender,
                Phone = tData.Phone,
                PostalCode = tData.PostalCode,
                RegionCityId = tData.TRegionCityId ?? 0,
                RegionStateId = tData.TRegionCity?.TRegionStateId ?? 0,
                RegionCountryId = tData.TRegionCity?.TRegionState?.TRegionCountryId ?? 0,
                RestaurantName = tData.RestaurantName
            };

            return result;
        }
    }
}
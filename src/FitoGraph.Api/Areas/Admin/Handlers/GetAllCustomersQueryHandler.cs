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

namespace FitoGraph.Api.Areas.Customer.Handlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, ResultWrapper<GetAllCustomersOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetAllCustomersQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetAllCustomersOutput>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetAllCustomersOutput> result = new ResultWrapper<GetAllCustomersOutput>();

            var tDataList = await _dbContext.TUser
            .Where(x => x.Role == Infrastructure.AppEnums.RoleEnum.Customer)
            .Skip(request.pageSize * (request.pageNumber - 1))
            .Take(request.pageSize)
            .ToListAsync();

            int totalItems = await _dbContext.TUser
                        .Where(x => x.Role == Infrastructure.AppEnums.RoleEnum.Customer)
                        .CountAsync();

            var list = tDataList.Select(x => new PublicListItem()
            {
                Enabled = x.Enabled,
                Selected = x.FireBaseId == request.firebaseId,
                Text = x.Email,
                Value = x.Id.ToString(),
                Image = string.Empty
            })
            .ToList();
            result.Status = true;
            result.Result = new GetAllCustomersOutput()
            {
                list = list,
                pageSize = request.pageSize,
                pageNumber = request.pageNumber,
                totalItems = totalItems
            };

            return result;
        }
    }
}
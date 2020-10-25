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
    public class GetAllAdminsQueryHandler : IRequestHandler<GetAllAdminsQuery, ResultWrapper<GetAllAdminsOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetAllAdminsQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetAllAdminsOutput>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetAllAdminsOutput> result = new ResultWrapper<GetAllAdminsOutput>();

            var tDataList = await _dbContext.TUser.Where(x => x.Role == Infrastructure.AppEnums.RoleEnum.Admin).ToListAsync();
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
            result.Result = new GetAllAdminsOutput()
            {
                list = list
            };

            return result;
        }
    }
}
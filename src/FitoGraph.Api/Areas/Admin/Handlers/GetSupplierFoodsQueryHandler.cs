using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Areas.Admin.Queries;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class GetSupplierFoodsQueryHandler : IRequestHandler<GetSupplierFoodsQuery, ResultWrapper<GetSupplierFoodsOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetSupplierFoodsQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetSupplierFoodsOutput>> Handle(GetSupplierFoodsQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetSupplierFoodsOutput> result = new ResultWrapper<GetSupplierFoodsOutput>();

            var tDataList = await _dbContext.TFood
                .Where(x => x.TUserId == request.SupplierId)                
                .ToListAsync();
            var list = tDataList.Select(x => new PublicListItem()
            {
                Enabled = x.Enabled,
                Selected = false,
                Text = x.Title,
                Value = x.Id.ToString(),
                Image = x.Image.JoinWithCDNAddress()
            })
            .ToList();
            result.Status = true;
            result.Result = new GetSupplierFoodsOutput()
            {
                list = list
            };

            return result;
        }
    }
}
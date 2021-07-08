using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Supplier.Queries;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Entities;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Helpers.FireBase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitoGraph.Api.Areas.Supplier.Handlers
{
    public class GetSupplierOrdersQueryHandler : IRequestHandler<GetSupplierOrdersQuery, ResultWrapper<GetSupplierOrdersOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetSupplierOrdersQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public Task<ResultWrapper<GetSupplierOrdersOutput>> Handle(GetSupplierOrdersQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetSupplierOrdersOutput> result = new ResultWrapper<GetSupplierOrdersOutput>();


            TUser tUser = _dbContext.TUser.FirstOrDefault(x => x.FireBaseId == request.firebaseId);
            if (tUser == null)
            {
                result.Status = false;
                result.Message = "cannot find supplier!";
                return Task.FromResult(result);
            }

            var list = _dbContext.TOrder
                .Include(x => x.TSupplier)
                .Where(x => x.TSupplierId == tUser.Id)
                .Select(tData => new GetSupplierOrdersOutput.OrderItem()
                {
                    Id = tData.Id,
                    Title = tData.Title,
                    TotalPayablePrice = tData.TotalPayablePrice,
                    Customer = tData.TUser.FirstName + " " + tData.TUser.LastName,
                    Date = tData.Date
                })
            .ToList();
            result.Status = true;
            result.Result = new GetSupplierOrdersOutput()
            {
                list = list
            };

            return Task.FromResult(result);
        }
    }
}
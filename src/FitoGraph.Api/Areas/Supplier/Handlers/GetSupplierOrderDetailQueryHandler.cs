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
    public class GetSupplierOrderDetailQueryHandler : IRequestHandler<GetSupplierOrderDetailQuery, ResultWrapper<GetSupplierOrderDetailOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public GetSupplierOrderDetailQueryHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<GetSupplierOrderDetailOutput>> Handle(GetSupplierOrderDetailQuery request, CancellationToken cancellationToken)
        {
            ResultWrapper<GetSupplierOrderDetailOutput> result = new ResultWrapper<GetSupplierOrderDetailOutput>();


            TUser tUser = await _dbContext.TUser.FirstOrDefaultAsync(x => x.FireBaseId == request.firebaseId);
            if (tUser == null)
            {
                result.Status = false;
                result.Message = "cannot find customer!";
                return result;
            }

            var tData = await _dbContext.TOrder
                .Include(x => x.TUser)
                .Include(x => x.TOrderDetails).ThenInclude(x => x.TFood)
                .FirstOrDefaultAsync(x => x.Id == request.orderId && x.TSupplierId == tUser.Id);

            if (tData == null)
            {
                result.Status = false;
                result.Message = "this order doesn't exists";
                return result;
            }
            result.Status = true;
            result.Result = new GetSupplierOrderDetailOutput()
            {
                Id = tData.Id,
                Title = tData.Title,
                TotalPayablePrice = tData.TotalPayablePrice,
                Customer = tData.TUser.FirstName + " " + tData.TUser.LastName,
                Date = tData.Date,
                list = tData.TOrderDetails.Select(x => new GetSupplierOrderDetailOutput.OrderDetailItem()
                {
                    Id = x.Id,
                    FoodId = x.TFoodId,
                    FoodName = x.TFood.Title,
                    Amount = x.Amount,
                    UnitPrice = x.UnitPrice,
                    RowPrice = x.RowPrice
                }).ToList()
            };

            return result;
        }
    }
}
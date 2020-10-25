using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Admin.Commands;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Domain.DB;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Helpers.FireBase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitoGraph.Api.Areas.Admin.Handlers
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, ResultWrapper<DeleteSupplierOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public DeleteSupplierCommandHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<DeleteSupplierOutput>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<DeleteSupplierOutput> result = new ResultWrapper<DeleteSupplierOutput>();
            try
            {
                var tData = await _dbContext.TUser.FirstOrDefaultAsync(x => x.Id == request.UserId && x.Role == Infrastructure.AppEnums.RoleEnum.Supplier);
                if (tData == null)
                {
                    result.Status = false;
                    result.Message = "Supplier doesn't exists";
                    return result;
                }
                _dbContext.TUser.Remove(tData);
                await _dbContext.SaveChangesAsync();
                result.Status = true;
                result.Result = new DeleteSupplierOutput()
                {
                    FireBaseId = tData.FireBaseId
                };
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
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
    public class DeleteAdminCommandHandler : IRequestHandler<DeleteAdminCommand, ResultWrapper<DeleteAdminOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        private readonly AppDbContext _dbContext;
        public DeleteAdminCommandHandler(IFireBaseTool fireBaseTool, AppDbContext dbContext)
        {
            _fireBaseTool = fireBaseTool;
            _dbContext = dbContext;
        }

        public async Task<ResultWrapper<DeleteAdminOutput>> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<DeleteAdminOutput> result = new ResultWrapper<DeleteAdminOutput>();
            try
            {
                var tData = await _dbContext.TUser.FirstOrDefaultAsync(x => x.Id == request.UserId && x.Role == Infrastructure.AppEnums.RoleEnum.Admin);
                if (tData == null)
                {
                    result.Status = false;
                    result.Message = "User doesn't exists";
                    return result;
                }
                _dbContext.TUser.Remove(tData);
                await _dbContext.SaveChangesAsync();
                result.Status = true;
                result.Result = new DeleteAdminOutput()
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
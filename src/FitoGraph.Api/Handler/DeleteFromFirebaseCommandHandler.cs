using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.FireBase;
using FitoGraph.Api.Helpers.Lib;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FitoGraph.Api.Commands.Handler
{
    public class DeleteFromFirebaseCommandHandler : IRequestHandler<DeleteFromFirebaseCommand, ResultWrapper<DeleteFromFirebaseOutput>>
    {
        private readonly IFireBaseTool _fireBaseTool;
        public DeleteFromFirebaseCommandHandler(IFireBaseTool fireBaseTool)
        {
            _fireBaseTool = fireBaseTool;
        }

        public async Task<ResultWrapper<DeleteFromFirebaseOutput>> Handle(DeleteFromFirebaseCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<DeleteFromFirebaseOutput> deleteResult = new ResultWrapper<DeleteFromFirebaseOutput>();
        
            DeleteUserRequest deleteUserReq = new DeleteUserRequest()
            {
                idToken = request.IdToken                
            };
            ResultWrapper<DeleteUserResponse> deleteUserResult = await _fireBaseTool.DeleteUser(deleteUserReq);

            if (!deleteUserResult.Status)
            {
                deleteResult.Status = false;
                deleteResult.Message = deleteUserResult.Message;
                return deleteResult;
            }
            deleteResult.Status = true;
            deleteResult.Result = new DeleteFromFirebaseOutput()
            {
            };

            return deleteResult;
        }
    }
}
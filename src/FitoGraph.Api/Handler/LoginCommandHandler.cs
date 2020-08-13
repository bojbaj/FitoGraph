using System;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Auth;
using FitoGraph.Api.Helpers;
using FitoGraph.Api.Helpers.Settings;
using FitoGraph.Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FitoGraph.Api.Commands.Handler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResultWrapper<LoginOutput>>
    {
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public LoginCommandHandler(IMapper mapper, IOptionsSnapshot<AppSettings> appSettings)
        {
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public async Task<ResultWrapper<LoginOutput>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            ResultWrapper<LoginOutput> result = new ResultWrapper<LoginOutput>()
            {
                Result = new LoginOutput()
            };
            if (!request.Username.Equals("u1@site.com"))
            {
                result.Message = "Username or Password is invalid";
                return result;
            }
            result.Result.Token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjQ5ZTg4YzUzNzYxOTk2YTczNjIzZjE5MWQ1MTJkMmI0N2RmODAyYTEiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL3NlY3VyZXRva2VuLmdvb2dsZS5jb20vZGV2cHJvamVjdC1kZWJ1ZyIsImF1ZCI6ImRldnByb2plY3QtZGVidWciLCJhdXRoX3RpbWUiOjE1OTczMTYwMzEsInVzZXJfaWQiOiJMWHJ0QVl4VGlZYUx3andEVEg5c1Y5OVRQRGUyIiwic3ViIjoiTFhydEFZeFRpWWFMd2p3RFRIOXNWOTlUUERlMiIsImlhdCI6MTU5NzMxNjAzMSwiZXhwIjoxNTk3MzE5NjMxLCJlbWFpbCI6InUxQHNpdGUuY29tIiwiZW1haWxfdmVyaWZpZWQiOmZhbHNlLCJmaXJlYmFzZSI6eyJpZGVudGl0aWVzIjp7ImVtYWlsIjpbInUxQHNpdGUuY29tIl19LCJzaWduX2luX3Byb3ZpZGVyIjoicGFzc3dvcmQifX0.iuZI2u4pzY2mQ-DHVr5IEfKVIC5-PWUGUngOblzM79DI06t0z_47k1J-ssV-VarC7OfcI1Uu5-QLVw-YCNrxnnE6kq2bJ9CNYzkU-bg52P2nRW3FY2yIy17ELLltb2_dXatpIOB59KF2pISWTY2LKD6wp8TtbKUhHShnIiRlbZDI-CbjJkUJLqGf2BH7LL1Cr8HpdoRXoxXbkBS1Q6NqETtjbxDn_9Zp_4KlJOnQttLwuZJHjF23O8iJ2vof7dT05kq38THDZxAjEz0xTxs_ClSPLKOHiDpRJNPSw2JQMftUwez6FFDig2XhP6yHTinmIuDNvY0frWdPvZZwjn14_g";
            result.Status = !string.IsNullOrEmpty(result.Result.Token);
            return result;
        }
    }
}
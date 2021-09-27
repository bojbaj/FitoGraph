using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FitoGraph.Api.Areas.Admin.Commands;
using FitoGraph.Api.Areas.Admin.Outputs;
using FitoGraph.Api.Areas.Admin.Queries;
using FitoGraph.Api.Commands;
using FitoGraph.Api.Domain.Models;
using FitoGraph.Api.Domain.Models.Outputs;
using FitoGraph.Api.Domain.Models.User;
using FitoGraph.Api.Events;
using FitoGraph.Api.Filters;
using FitoGraph.Api.Infrastructure;
using FitoGraph.Api.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using static FitoGraph.Api.Infrastructure.AppEnums;
using FitoGraph.Api.Areas.Admin.Base;

namespace FitoGraph.Api.Areas.Articles.Controllers
{
    [UserVerification(RoleEnum.Admin)]
    public class ArticlesController : BaseAdminApiController
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetArticles()
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetAllArticlesQuery model = new GetAllArticlesQuery()
            {
                firebaseId = user.UserId
            };
            ResultWrapper<GetAllArticlesOutput> result = new ResultWrapper<GetAllArticlesOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetArticles(int id)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            GetArticleQuery model = new GetArticleQuery()
            {
                firebaseId = user.UserId,
                Id = id
            };
            ResultWrapper<GetArticleOutput> result = new ResultWrapper<GetArticleOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteArticles(DeleteArticleCommand model)
        {
            FirebaseUser user = HttpContext.GetFirebaseUser();
            model.FireBaseId = user.UserId;
            ResultWrapper<DeleteArticleOutput> result = new ResultWrapper<DeleteArticleOutput>();
            result = await _mediator.Send(model);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateArticleCommand createArticlesCommand)
        {
            ResultWrapper<CreateArticleOutput> createArticlesResult = await _mediator.Send(createArticlesCommand);
            return Ok(createArticlesResult);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateArticleCommand updateArticlesCommand)
        {
            ResultWrapper<UpdateArticleOutput> updateArticlesResult = await _mediator.Send(updateArticlesCommand);
            return Ok(updateArticlesResult);
        }
    }
}
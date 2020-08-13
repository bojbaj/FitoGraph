using FitoGraph.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Admin.Base
{
    [Area(nameof(RoleEnum.Admin))]
    public class BaseAdminApiController : BaseApiController
    {

    }
}
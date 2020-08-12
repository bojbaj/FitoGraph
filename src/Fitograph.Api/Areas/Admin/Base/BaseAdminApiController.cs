using Fitograph.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static Fitograph.Api.Infrastructure.AppEnums;

namespace Fitograph.Api.Areas.Admin.Base
{
    [Area(nameof(RoleEnum.Admin))]
    public class BaseAdminApiController : BaseApiController
    {

    }
}
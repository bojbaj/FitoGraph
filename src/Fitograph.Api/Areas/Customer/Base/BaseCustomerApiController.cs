using Fitograph.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static Fitograph.Api.Infrastructure.AppEnums;

namespace Fitograph.Api.Areas.Customer.Base
{
    [Area(nameof(RoleEnum.Customer))]
    public class BaseCustomerApiController : BaseApiController
    {

    }
}
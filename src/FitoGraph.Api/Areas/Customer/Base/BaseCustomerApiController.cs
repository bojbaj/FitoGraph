using FitoGraph.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Customer.Base
{
    [Area(nameof(RoleEnum.Customer))]
    public class BaseCustomerApiController : BaseApiController
    {

    }
}
using FitoGraph.Api.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using static FitoGraph.Api.Infrastructure.AppEnums;

namespace FitoGraph.Api.Areas.Supplier.Base
{
    [Area(nameof(RoleEnum.Supplier))]
    public class BaseSupplierApiController : BaseApiController
    {

    }
}
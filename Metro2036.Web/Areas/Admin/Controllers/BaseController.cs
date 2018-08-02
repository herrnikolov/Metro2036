namespace Metro2036.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using static Constants;
    
    [Area(AdministratorArea)]
    [Authorize(Roles = AdministratorRole)]

    public abstract class BaseController : Controller
    {
    }
}
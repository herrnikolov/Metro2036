namespace Metro2036.Web.Areas.User.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using static Constants;

    [Area(UserArea)]
    [Authorize(Roles = "User, Admin")]

    public class BaseController : Controller
    {
    }
}
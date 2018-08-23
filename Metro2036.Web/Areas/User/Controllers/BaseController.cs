namespace Metro2036.Web.Areas.User.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using static WebConstants;

    [Area(UserArea)]
    [Authorize(Roles = "User, Admin")]

    public class BaseController : Controller
    {
    }
}
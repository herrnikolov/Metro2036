namespace Metro2036.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
namespace Metro2036.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Metro2036.Models;
    using Metro2036.Services.Models;
    using Metro2036.Services.Interfaces;
    using System.Threading.Tasks;
    using Metro2036.Services.Models.User;
    using AutoMapper;

    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public UserController(
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            IUserService userService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this._userService.GetAll();

            return View(new UserListingViewModel { Users = users });
        }

        // GET: /TravelLogs/id
        public ActionResult TravelLogs(string id)
        {
            var travelLogs = this._userService.GetTravels(id);

            return View(travelLogs);
        }
    }
}
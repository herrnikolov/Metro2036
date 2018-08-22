namespace Metro2036.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Metro2036.Models;
    using Metro2036.Services.Models;
    using Metro2036.Services.Interfaces;

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

        public IActionResult Index()
        {
            //var allUsers = userService.GetAll();

            //var users = userManager.GetUsersInRoleAsync("User");

            var result = _userService.GetAll();

            return View(result);
        }

    }
}
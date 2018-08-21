namespace Metro2036.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Metro2036.Models;
    using Metro2036.Services.Models;

    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        //private readonly IUserService userService;

        public UserController(
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var allUsers = this.userManager.Users.ToList();
                        
            var allRoles = this.roleManager.Roles.Select(r => r.Name).ToList();

            //foreach (var userModel in allUsers)
            //{
            //    var dbUser = await this.userManager.FindByEmailAsync(userModel.Email);
            //    var userRoles = await this.userManager.GetRolesAsync(dbUser);
            //}

            //var model = new UserListingViewModel
            //{
            //    Users = new List<UserListingViewModel>(allUsers)
            //};

            //return View(model);
            return View();
        }

    }
}
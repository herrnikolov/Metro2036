namespace Metro2036.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using Metro2036.Models;
    using Metro2036.Web.Areas.Admin.Models.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Metro2036.Services.Interfaces;
    using AutoMapper;

    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public UserController(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var currentUser = _userManager.GetUserAsync(this.User);

            //TODO: Admin Can't Edit Themselves
            var allUsers = _userManager
                .Users
                .OrderBy(u => u.UserName);

            //var model = IAutoMapper.Map<IEnumerable<UserListingServiceModel>>(allUsers);

            var model = Mapper.Map<UserListingServiceModel>(allUsers);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Something went wrong while deleting this user.");
            }
            else
            {
                ModelState.AddModelError("", "This user can't be found");
            }
            return View("Index", _userManager.Users);
        }

    }
}
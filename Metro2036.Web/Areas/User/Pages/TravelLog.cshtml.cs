namespace Metro2036.Web.Areas.User.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Web.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.EntityFrameworkCore;
    using static WebConstants;

    [Area(UserArea)]
    [Authorize(Roles = UserRole)]
    public class TravelLogModel : PageModel
    {
        private Metro2036DbContext _context;
        private UserManager<User> _userManager;

        public TravelLogModel(Metro2036DbContext context,
               UserManager<User> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        public IEnumerable<TravelLogViewModel> Travels { get; set; }
        public void OnGet()
        {
            var currentUser = this._userManager.GetUserId(this.User);

            this.Travels = this._context.TravelLogs
                .Include(tl => tl.Station)
                .OrderBy(tl => tl.Id)
                .Where(tl => tl.UserId == currentUser)
                .Select(TravelLogViewModel.ListTravels)
                .ToList();
        }
    }
}
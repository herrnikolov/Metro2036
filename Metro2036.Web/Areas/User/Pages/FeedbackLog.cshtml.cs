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
    using static WebConstants;

    [Area(UserArea)]
    [Authorize(Roles = UserRole)]
    public class FeedbackLogModel : PageModel
    {
        private Metro2036DbContext _context;
        private UserManager<User> _userManager;

        public FeedbackLogModel(Metro2036DbContext context,
            UserManager<User> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        //public string UserId { get; set; }

        //public string Message { get; set; }

        public IEnumerable<FeedbackLogViewModel> Feedbacks { get; set; }

        public void OnGet()
        {
            var currentUser = this._userManager.GetUserId(this.User);

            this.Feedbacks = this._context.Feedbacks
                .Where(u => u.UserId == currentUser)
                .OrderBy(f => f.Id)
                .Select(FeedbackLogViewModel.ListFeedback)
                .ToList();

        }
    }
}
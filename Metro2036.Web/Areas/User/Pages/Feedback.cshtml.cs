namespace Metro2036.Web.Areas.User.Pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    using Metro2036.Data;
    using Metro2036.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using static WebConstants;

    [Area(UserArea)]
    [Authorize(Roles = UserRole)]
    public class FeedbackModel : PageModel
    {
        private Metro2036DbContext _context;
        private UserManager<User> _userManager;

        public FeedbackModel(Metro2036DbContext context,
            UserManager<User> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        [Required]
        public string UserId { get; set; }

        [BindProperty]
        [Required]
        [StringLength(2000, ErrorMessage = "Your Message is Required")]
        public string Message { get; set; }

        //POST
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return this.Page();
            }

            var currentUser = await this._userManager.GetUserAsync(this.User);

            var feedback = new Feedback()
            {
                UserId = currentUser.Id,
                Message = this.Message
            };

            this._context.Feedbacks.Add(feedback);
            this._context.SaveChanges();
            return this.RedirectToPage("FeedbackLog");
        }
    }
}
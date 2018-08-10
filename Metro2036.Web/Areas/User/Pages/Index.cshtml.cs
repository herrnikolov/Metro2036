namespace Metro2036.Web.Areas.User.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using static Constants;

    [Area(UserArea)]
    [Authorize(Roles = UserRole)]

    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
namespace Metro2036.Web.Areas.Admin.Models.User
{
    using System.Collections.Generic;

    public class UserListingViewModel
    {
        public IEnumerable<UserListingServiceModel> Users { get; set; }
    }
}

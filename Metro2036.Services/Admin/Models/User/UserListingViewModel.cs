namespace Metro2036.Services.Admin.Models.User
{
    using System.Collections.Generic;

    public class UserListingViewModel
    {
        public IEnumerable<UserListingServiceModel> Users { get; set; }
    }
}

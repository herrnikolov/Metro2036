namespace Metro2036.Services.Models.User
{
    using Metro2036.Common.Mapping;
    using Metro2036.Models;

    public class UserListingServiceModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string TravelCardId { get; set; }
    }
}
namespace Metro2036.Services.Admin.Interfaces
{
    using Metro2036.Services.Admin.Models.User;
    using System.Linq;

    public interface IUserService
    {
        IQueryable<UserListingServiceModel> GetAll();

    }
}

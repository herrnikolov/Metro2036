namespace Metro2036.Services.Interfaces
{
    using Metro2036.Models;
    using Metro2036.Services.Models.User;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<IEnumerable<UserListingServiceModel>> GetAll();


        IEnumerable<TravelLog> GetTravels(string id);
    }
}

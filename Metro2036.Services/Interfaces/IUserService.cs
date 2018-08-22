namespace Metro2036.Services.Interfaces
{
    using Metro2036.Models;
    using Metro2036.Services.Models.User;
    using System.Collections.Generic;
    using System.Linq;

    public interface IUserService
    {
        IEnumerable<User> GetAll();
    }
}

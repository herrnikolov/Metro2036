namespace Metro2036.Services.Implementations
{
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Services.Interfaces;
    using Metro2036.Services.Models.User;
    using System.Collections.Generic;
    using System.Linq;

    public class UserService : BaseService, IUserService
    {
        private readonly Metro2036DbContext _context;

        public UserService(Metro2036DbContext context)
        {
            _context = context;
        }

        //Get ALL | Index
        IEnumerable<User> IUserService.GetAll()
        {
            var users = _context.Users
                .OrderBy(u => u.UserName);

            return users;
        }
    }
}

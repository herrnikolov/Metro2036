namespace Metro2036.Services.Admin.Implementations
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Metro2036.Data;
    using Metro2036.Services.Admin.Interfaces;
    using Metro2036.Services.Admin.Models.User;
    using System.Linq;

    public class UserService : BaseService, IUserService
    {
        private Metro2036DbContext _context;

        public UserService(Metro2036DbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
        }

        public IQueryable<UserListingServiceModel> GetAll()
        {
            var result = _context.Users
                .OrderBy(u => u.UserName)
                .ProjectTo<UserListingServiceModel>();

            return result;
        }

        IQueryable<UserListingServiceModel> IUserService.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}

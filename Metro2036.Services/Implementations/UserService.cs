namespace Metro2036.Services.Implementations
{
    using Metro2036.Data;
    using Metro2036.Services.Interfaces;
    using Metro2036.Services.Models.User;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using Metro2036.Models;

    public class UserService : BaseService, IUserService
    {
        private readonly Metro2036DbContext _context;

        public UserService(Metro2036DbContext context)
        {
            _context = context;
        }

        //Get ALL | Index
        public async Task<IEnumerable<UserListingServiceModel>> GetAll()
            => await this._context
            .Users
            .OrderBy(u => u.UserName)
            .ProjectTo<UserListingServiceModel>()
            .ToListAsync();

        //Get by ID | Details
        public IEnumerable<TravelLog> GetTravels(string id)
        {
            var travellog =  _context.TravelLogs
                .Include(tl => tl.Station)
                .Include(tl => tl.User)
                .Where(tl => tl.UserId == id);
            return travellog;
        }
    }
}

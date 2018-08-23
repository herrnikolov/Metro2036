namespace Metro2036.Services.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class RouteService : BaseService, IRouteService
    {
        private Metro2036DbContext _context;

        public RouteService(Metro2036DbContext context)
        {
            _context = context;
        }

        //Get ALL | Index
        //public IEnumerable<Route> GetAll()
        //{
        //    //return _context.Routes.OrderBy(r => r.RouteId);
        //    var route = this._context.
        //        Routes
        //        .OrderByDescending(r => r.Id)
        //        .ToList();
        //    return route;

        //}
        public async Task<IEnumerable<TModel>> GetAll<TModel>() where TModel : class
            => await this._context.Routes
            .OrderBy(r => r.Id)
            .ProjectTo<TModel>()
            .ToListAsync();

        //Get by ID | Details
        public Route Get(int id)
        {
            return _context.Routes.FirstOrDefault(r => r.Id == id);
        }

        //ADD | Create
        public Route Add(Route route)
        {
            _context.Routes.Add(route);
            _context.SaveChanges();
            return route;
        }

        //Update | Edit
        public Route Update(Route route)
        {
            _context.Routes.Update(route);
            _context.SaveChanges();
            return route;
        }

        //Remove | Delete
        public Route Delete(Route route)
        {
            _context.Routes.Remove(route);
            _context.SaveChanges();
            return route;
        }
    }
}

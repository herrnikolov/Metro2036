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

    public class PointService : BaseService, IPointService
    {
        private Metro2036DbContext _context;

        public PointService(Metro2036DbContext context)
        {
            _context = context;
        }

        //Get ALL | Index
        public async Task<IEnumerable<TModel>> GetAll<TModel>() where TModel : class
            => await this._context.Points
            .OrderBy(t => t.Id)
            .ProjectTo<TModel>()
            .ToListAsync();

        public Point Add(Point route)
        {
            throw new System.NotImplementedException();
        }

        public Point Delete(Point route)
        {
            throw new System.NotImplementedException();
        }

        public Point Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Point Update(Point route)
        {
            throw new System.NotImplementedException();
        }
    }
}

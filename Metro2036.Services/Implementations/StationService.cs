using Metro2036.Data;
using Metro2036.Models;
using Metro2036.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metro2036.Services.Implementations
{
    public class StationService : BaseService, IStationService
    {
        private Metro2036DbContext _context;

        //public StationService(Metro2036DbContext db) : base(db) { }

        public StationService(Metro2036DbContext context)
        {
            _context = context;
        }

        public Station Add(Station station)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
            return station;
        }

        public Station Get(int id)
        {
            return _context.Stations.FirstOrDefault(s => s.Id == id);
        }

        public IEquatable<Station> GetAll()
        {
            return _context.Stations.OrderBy(s => s.Name);
        }

        public Station Update(Station station)
        {
            _context.Attach(station).State =
                EntityState.Modified;
            _context.SaveChanges();
            return station;
        }
    }
}

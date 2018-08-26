namespace Metro2036.Services.Implementations
{
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Services.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class StationService : BaseService, IStationService
    {
        private Metro2036DbContext _context;

        public StationService(Metro2036DbContext context)
        {
            _context = context;
        }

        //Get ALL | Index
        IEnumerable<Station> IStationService.GetAll()
        {
            return _context.Stations.OrderBy(s => s.StantionId);
        }
        //ADD | Create
        public Station Add(Station station)
        {
            _context.Stations.Add(station);
            _context.SaveChanges();
            return station;
        }

        //Get by ID | Details
        public Station Get(int id)
        {
            return _context.Stations.FirstOrDefault(s => s.Id == id);
        }
        //Update | Edit
        public Station Update(Station station)
        {
            //_context.Stations.Attach(station).State =
            //    EntityState.Modified;
            _context.Stations.Update(station);
            _context.SaveChanges();
            return station;
        }

        //Remove | Delete
        public Station Delete(Station station)
        {
            _context.Stations.Remove(station);
            _context.SaveChanges();
            return station;
        }
    }
}

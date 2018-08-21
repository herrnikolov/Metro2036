namespace Metro2036.Services.Admin.Implementations
{
    using AutoMapper;
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Services.Admin.Interfaces;
    using Metro2036.Services.Admin.Models.Station;
    using System.Collections.Generic;
    using System.Linq;

    public class StationService : BaseService, IStationService
    {

        public StationService(Metro2036DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        //ADD
        StationCreateViewModel IStationService.Add(stationcreate station)
        {
            DbContext.Stations.Add(station);
            DbContext.SaveChanges();
            return station;
        }

        //Get by ID | Details
        StationDetailsViewModel IStationService.Get(int stationId)
        {
            var model = DbContext.Stations.FirstOrDefault(s => s.Id == stationId);
            var result = this.Mapper<StationDetailsViewModel>(model);
            return result;
        }

        //Get ALL | Index
        public IEnumerable<StationIndexViewModel> GetAll()
        {
            return DbContext.Stations.OrderBy(s => s.StantionId);
        }

        //Update | Edit
        public Station Update(Station station)
        {
            //_context.Stations.Attach(station).State =
            //    EntityState.Modified;
            DbContext.Stations.Update(station);
            DbContext.SaveChanges();
            return station;
        }

        //Remove | Delete
        public Station Delete(Station station)
        {
            DbContext.Stations.Remove(station);
            DbContext.SaveChanges();
            return station;
        }
    }
}

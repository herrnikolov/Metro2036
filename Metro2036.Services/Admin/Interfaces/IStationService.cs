namespace Metro2036.Services.Admin.Interfaces
{
    using Metro2036.Models;
    using Metro2036.Services.Admin.Models.Station;
    using System.Collections.Generic;

    public interface IStationService
    {
        IEnumerable<StationIndexViewModel> GetAll();

        StationDetailsViewModel Get(int stationId);

        StationCreateViewModel Add(Station station);

        Station Update(Station station);

        Station Delete(Station stationId);
    }
}

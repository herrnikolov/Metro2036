namespace Metro2036.Services.Interfaces
{
    using Metro2036.Models;
    using System;
    using System.Collections.Generic;

    public interface IStationService
    {
        IEnumerable<Station> GetAll();

        Station Get(int id);

        Station Add(Station station);

        Station Update(Station station);

        Station Delete(Station station);
    }
}

namespace Metro2036.Services.Implementations
{
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Services.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    public class TimingService : BaseService, ITimingService
    {
        private Metro2036DbContext _context;
        public TimingService(Metro2036DbContext context)
        {
            _context = context;
        }

        //Get by ID | Details
        public Station GetTime(int StantionId)
        {
            string json;
            using (var client = new WebClient())
            {
                json = client.DownloadString("http://drone.sumc.bg/api/v1/metro/times/"+ StantionId);
            }

            throw new NotImplementedException();
        }
    }
}

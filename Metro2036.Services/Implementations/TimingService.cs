namespace Metro2036.Services.Implementations
{
    using Metro2036.Data;
    using Metro2036.Models;
    using Metro2036.Services.Interfaces;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Linq;
    using System.Globalization;

    public class StationTimingsDtoImp
    {
        [JsonProperty("route_1")]
        public string route01 { get; set; }

        [JsonProperty("route_2")]
        public string route02 { get; set; }

        [JsonProperty("route_1_name")]
        public string RouteName01 { get; set; }

        [JsonProperty("route_2_name")]
        public string RouteName02 { get; set; }
    }
    public class TimingService : BaseService, ITimingService
    {
        private Metro2036DbContext _context;
        public TimingService(Metro2036DbContext context)
        {
            _context = context;
        }

        //Get by ID | Details
        public DateTime[] GetTime(int StantionId)
        {
            string json;
            using (var client = new WebClient())
            {
                json = client.DownloadString("http://drone.sumc.bg/api/v1/metro/times/"+ StantionId);
            }

            var deserializedTimes = JsonConvert.DeserializeObject<StationTimingsDtoImp>(json);

            var currentTime = DateTime.Now;

            var route01Timings = deserializedTimes.route01
                .Split(',')
                .Select(x => DateTime.ParseExact(x, "HH:mm", CultureInfo.InvariantCulture))
                .Where(x => x > currentTime)
                .Take(10)
                .ToArray();

            return route01Timings;
        }
    }
}

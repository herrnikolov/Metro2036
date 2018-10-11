namespace Metro2036.Web.Models.Dto.ImportDTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class StationTimingsDtoImp
    {
        [JsonProperty("route_1")]
        public List<string> route01 { get; set; }

        [JsonProperty("route_2")]
        public List<string> route02 { get; set; }

        [JsonProperty("route_1_name")]
        public string RouteName01 { get; set; }

        [JsonProperty("route_2_name")]
        public string RouteName02 { get; set; }
    }
}

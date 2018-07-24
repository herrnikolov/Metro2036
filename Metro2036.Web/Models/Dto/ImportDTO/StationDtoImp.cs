namespace Metro2036.Web.Models.DTO.ImportDTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public class StationDtoImp
    {
        public int Id { get; set; }

        [JsonProperty("id")]
        public int StantionId { get; set; }
        
        [JsonProperty("route_id")]
        public int RouteId { get; set; }

        public int Code { get; set; }

        [JsonProperty("point_id")]
        public int PointId { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}

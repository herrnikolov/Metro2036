namespace Metro2036.Web.Models.DTO.ImportDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Metro2036.Models;
    using Newtonsoft.Json;

    public class RouteDtoImp
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty("routes_id")]
        public int RouteId { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("route_name")]
        public string RouteName { get; set; }

        [JsonProperty("line_id")]
        public int LineId { get; set; }

        [JsonProperty("id")]
        public int ExtId { get; set; }

        [JsonProperty("line_name")]
        public int LineName { get; set; }

        [JsonProperty("points")]
        public ICollection<Point> Points { get; set; }
    }
}

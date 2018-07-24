namespace Metro2036.Web.Models.DTO.ImportDTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public class PointDtoImp
    {
        [JsonProperty("stop")]
        public int stop { get; set; }

        [JsonProperty("stopCode")]
        public int StopCode { get; set; }

        [JsonProperty("StopName")]
        public string StopName { get; set; }

        [JsonProperty("lat")]
        public decimal Latitude { get; set; }

        [JsonProperty("lon")]
        public decimal Longitude { get; set; }

        [JsonProperty("vehicleType")]
        public int VehicleType { get; set; }
    }
}

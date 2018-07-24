namespace Metro2036.Web.Models.DTO.ImportDTO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Metro2036.Models;
    using Newtonsoft.Json;

    public class TrainDtoImp
    {
        [JsonProperty("Maker")]
        public string Maker { get; set; }

        [JsonProperty("OperationalSpeed")]
        public int OperationalSpeed { get; set; }

        [JsonProperty("Capacity")]
        public int Capacity { get; set; }

        [JsonProperty("YearOfManufacturing")]
        public DataType YearOfManufacturing { get; set; }

        [JsonProperty("SerialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("RouteId")]
        public int RouteId { get; set; }
    }
}

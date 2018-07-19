﻿namespace Metro2036.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Station
    {
        [Key]
        public int Id { get; set; }

        public int StantionId { get; set; }

        public int RouteId { get; set; }

        public int Code { get; set; }

        public int PointId { get; set; }

        public string Name { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public ICollection<RouteStation> RouteStations { get; set; } = new List<RouteStation>();
    }
}

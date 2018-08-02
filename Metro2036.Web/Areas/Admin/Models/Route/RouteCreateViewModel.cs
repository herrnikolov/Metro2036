namespace Metro2036.Web.Models.Route
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class RouteCreateViewModel
    {
        [Required]
        public int RouteId { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public string RouteName { get; set; }

        [Required]
        public int LineId { get; set; }

        [Required]
        public int ExtId { get; set; }

        [Required]
        public int LineName { get; set; }

        //public IEnumerable<Point> Points { get; set; }

        //public IEnumerable<RouteStation> RouteStations { get; set; }

        //public IEnumerable<Train> Trains { get; set; }
    }
}

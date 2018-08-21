namespace Metro2036.Services.Admin.Models.Route
{
    using System.Collections.Generic;

    public class RouteDetailsViewModel
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int Type { get; set; }

        public string RouteName { get; set; }

        public int LineId { get; set; }

        public int ExtId { get; set; }

        public int LineName { get; set; }

        //public IEnumerable<Point> Points { get; set; }

        //public ICollection<RouteStation> RouteStations { get; set; }

        //public ICollection<Train> Trains { get; set; }
    }
}

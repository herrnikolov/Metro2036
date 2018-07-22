namespace Metro2036.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Route
    {
        [Key]
        public int Id { get; set; }

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

        public ICollection<Point> Points { get; set; } = new List<Point>();

        public ICollection<RouteStation> RouteStations { get; set; } = new List<RouteStation>();

        public ICollection<Train> Trains { get; set; } = new List<Train>();
    }
}

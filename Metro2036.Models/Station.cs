namespace Metro2036.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Station
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StantionId { get; set; }

        [Required]
        public int RouteId { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public int PointId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        public ICollection<RouteStation> RouteStations { get; set; } = new List<RouteStation>();

        public ICollection<TravelLog> TravelLogs { get; set; } = new List<TravelLog>();
    }
}

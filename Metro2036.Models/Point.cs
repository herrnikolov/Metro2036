namespace Metro2036.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Point
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int stop { get; set; }

        [Required]
        public int StopCode { get; set; }

        public string StopName { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public int VehicleType { get; set; }
    }
}

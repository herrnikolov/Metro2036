namespace Metro2036.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Train
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Maker { get; set; }

        [Required]
        public int OperationalSpeed { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public DataType YearOfManufacturing { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public int RouteId { get; set; }

        [Required]
        public Route Route { get; set; }

    }
}

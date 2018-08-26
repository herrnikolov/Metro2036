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
        public int Speed { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Year")]
        public DataType Year { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [Required]
        public string SerialNumber { get; set; }

        [Required]
        public int RouteId { get; set; }

        [Required]
        public Route Route { get; set; }

    }
}

namespace Metro2036.Services.Models.Station
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class StationCreateViewModel
    {
        [Required]
        public int StantionId { get; set; }

        [Required]
        [Display(Name = "Route Id")]
        public int RouteId { get; set; }

        [Required]
        [Range(1, 20)]
        public int Code { get; set; }

        [Required]
        [Display(Name = "Point Id")]
        public int PointId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Please enter Station Name")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal Latitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal Longitude { get; set; }
    }
}

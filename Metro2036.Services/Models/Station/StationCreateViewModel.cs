using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Metro2036.Services.Models.Station
{
    public class StationCreateViewModel
    {
        [Required]
        public int StantionId { get; set; }

        [Required]
        public int RouteId { get; set; }

        [Required]
        public int Code { get; set; }

        [Required]
        public int PointId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal Latitude { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,6)")]
        public decimal Longitude { get; set; }
    }
}

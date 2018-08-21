namespace Metro2036.Services.Admin.Models.Point
{
    using System.ComponentModel.DataAnnotations;
    public class PointCreateViewModel
    {
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

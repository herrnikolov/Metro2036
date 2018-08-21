namespace Metro2036.Services.Admin.Models.Station
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.ComponentModel.DataAnnotations;
    public class StationEditBindModel
    {
        //[BindNever]
        [Required]
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

    }
}

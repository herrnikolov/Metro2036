namespace Metro2036.Web.Models.Point
{
    using System.ComponentModel.DataAnnotations;
    public class PointDetailsViewModel
    {
        public int Id { get; set; }

        public int stop { get; set; }

        public int StopCode { get; set; }

        public string StopName { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int VehicleType { get; set; }
    }
}

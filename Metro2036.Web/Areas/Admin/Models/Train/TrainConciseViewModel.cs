namespace Metro2036.Web.Areas.Admin.Models.Train
{
    using Metro2036.Models;
    using System.ComponentModel.DataAnnotations;
    public class TrainConciseViewModel
    {
        public int Id { get; set; }

        public string Maker { get; set; }

        public int Speed { get; set; }

        public int Capacity { get; set; }

        public DataType Year { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        public string SerialNumber { get; set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }
    }
}

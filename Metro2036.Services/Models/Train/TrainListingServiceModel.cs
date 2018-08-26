namespace Metro2036.Web.Areas.Admin.Models.Train
{
    using Metro2036.Models;
    using Metro2036.Common.Mapping;
    using System.ComponentModel.DataAnnotations;
    public class TrainListingServiceModel : IMapFrom<Train>
    {
        public int Id { get; set; }

        public string Maker { get; set; }

        public int Speed { get; set; }

        public int Capacity { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Year")]
        public DataType Year { get; set; }

        [Url]
        [Display(Name = "Train Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Serial Number")]
        [StringLength(50, ErrorMessage = "Please enter Valid Serial Number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Route Id")]
        public int RouteId { get; set; }

        public Route Route { get; set; }
    }
}

namespace Metro2036.Services.Models.Route
{
    using Metro2036.Common.Mapping;
    using Metro2036.Models;
    using System.ComponentModel.DataAnnotations;

    public class RouteListingServiceModel : IMapFrom<Route>
    {
        public int Id { get; set; }

        public int Type { get; set; }

        [Display(Name = "Ext Id")]
        public int ExtId { get; set; }

        [Display(Name = "Route Id")]
        public int RouteId { get; set; }

        [Display(Name = "Route Name")]
        public string RouteName { get; set; }

        [Display(Name = "Line Id")]
        public int LineId { get; set; }

        [Display(Name = "Line Name")]
        public int LineName { get; set; }
    }
}

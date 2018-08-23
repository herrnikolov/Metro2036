namespace Metro2036.Services.Models.Route
{
    using Metro2036.Common.Mapping;
    using Metro2036.Models;

    public class RouteListingServiceModel : IMapFrom<Route>
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public int ExtId { get; set; }

        public int RouteId { get; set; }

        public string RouteName { get; set; }

        public int LineId { get; set; }

        public int LineName { get; set; }
    }
}

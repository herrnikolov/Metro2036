namespace Metro2036.Services.Models.Route
{
    using System.Collections.Generic;
    using Metro2036.Models;

    public class RouteIndexViewModel
    {
        public IEnumerable<RouteListingViewModel> Routes { get; set; }
    }
}

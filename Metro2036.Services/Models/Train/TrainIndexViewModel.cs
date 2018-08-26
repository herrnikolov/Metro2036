namespace Metro2036.Services.Models.Train
{
    using Metro2036.Web.Areas.Admin.Models.Train;
    using System.Collections.Generic;

    public class TrainIndexViewModel
    {
        public IEnumerable<TrainListingServiceModel> Trains { get; set; }
    }
}

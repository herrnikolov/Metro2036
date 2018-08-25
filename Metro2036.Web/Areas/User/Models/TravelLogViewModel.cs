namespace Metro2036.Web.Models
{
    using Metro2036.Models;
    using System;

    public class TravelLogViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int StationId { get; set; }

        public Station Station { get; set; }

        public static Func<TravelLog, TravelLogViewModel> ListTravels
        {
            get
            {
                return travel => new TravelLogViewModel()
                {
                    Id = travel.Id,
                    UserId = travel.UserId,
                    StationId = travel.StationId,
                    Station = travel.Station
                };
            }
        }
    }
}

namespace Metro2036.Services.Models.User
{
    using Metro2036.Common.Mapping;
    using Metro2036.Models;
    public class UserTravelLogs : IMapFrom<TravelLog>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int StationId { get; set; }

        public Station Station { get; set; }
    }
}

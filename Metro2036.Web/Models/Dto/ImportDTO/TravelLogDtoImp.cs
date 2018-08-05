namespace Metro2036.Web.Models.DTO.ImportDTO
{
    using Metro2036.Models;
    public class TravelLogDtoImp
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public User User { get; set; }

        public int StationId { get; set; }

        public Station Station { get; set; }
    }
}

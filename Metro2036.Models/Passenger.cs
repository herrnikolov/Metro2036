namespace Metro2036.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Passenger
    {
        [Key]
        public int Id { get; set; }
        
        public string TravelId { get; set; }

    }
}

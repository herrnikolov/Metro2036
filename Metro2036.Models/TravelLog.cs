namespace Metro2036.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TravelLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TravelCardId { get; set; }

        public string UserName { get; set; }

        [Required]
        public int StationId { get; set; }

        public string StationName { get; set; }
    }
}

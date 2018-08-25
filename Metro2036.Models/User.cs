namespace Metro2036.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {        
        public string TravelCardId { get; set; }

        public ICollection<TravelLog> Travels { get; set; } = new List<TravelLog>();

        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}

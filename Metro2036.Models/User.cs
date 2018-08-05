namespace Metro2036.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        //[Key]
        //public int Id { get; set; }
        
        public string TravelCardId { get; set; }

        public ICollection<TravelLog> Travels { get; set; } = new List<TravelLog>();
    }
}

namespace Metro2036.Models
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        //[Key]
        //public int Id { get; set; }
        
        public string TravelId { get; set; }

    }
}

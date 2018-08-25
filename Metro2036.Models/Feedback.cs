namespace Metro2036.Models
{
    using System.ComponentModel.DataAnnotations;
    
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Your Message is Required")]
        public string Message { get; set; }
    }
}

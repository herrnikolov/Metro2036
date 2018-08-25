namespace Metro2036.Web.Models
{
    using Metro2036.Models;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.ComponentModel.DataAnnotations;

    public class FeedBack
    {
        [BindNever]
        public int FeedbackId { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Your Name is Required")]
        public string UserName { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Your Message is Required")]
        public string Message { get; set; }
    }
}

namespace Metro2036.Web.Models
{
    using Metro2036.Models;
    using System;

    public class FeedbackLogViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public string Message { get; set; }

        public static Func<Feedback, FeedbackLogViewModel> ListFeedback
        {
            get
            {
                return feedback => new FeedbackLogViewModel()
                {
                    Id = feedback.Id,
                    UserId = feedback.UserId,
                    User = feedback.User,
                    Message = feedback.Message
                };
            }
        }
    }
}

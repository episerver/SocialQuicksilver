using System;

namespace EPiServer.Reference.Social.Reviews.ViewModels
{
    public class ReviewViewModel
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public string Nickname { get; set; }

        public string Location { get; set; }

        public int Rating { get; set; }

        public DateTime AddedOn { get; set; }
    }
}
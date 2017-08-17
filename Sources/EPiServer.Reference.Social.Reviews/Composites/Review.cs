using EPiServer.Social.Common;

namespace EPiServer.Reference.Social.Reviews.Composites
{
    [ExtensionData("74dc360f-354b-4614-8d75-3f1e0263d946")]
    public class Review
    {
        public string Title { get; set; }

        public string Nickname { get; set; }

        public string Location { get; set; }

        public ReviewRating Rating { get; set; }
    }
}

using EPiServer.Reference.Social.Reviews.ViewModels;

namespace EPiServer.Reference.Social.Reviews.Services
{
    public interface IReviewService
    {
        void Add(ReviewSubmissionViewModel review);
        ReviewsViewModel Get(string productCode);
    }
}

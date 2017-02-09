using System.Collections.Generic;

namespace EPiServer.Reference.Social.Reviews.ViewModels
{
    public class ReviewsViewModel
    {
        public ReviewsViewModel()
        {
            this.Reviews = new List<ReviewViewModel>();
            this.Statistics = new ReviewStatisticsViewModel();
        }

        public ReviewStatisticsViewModel Statistics { get; set; }        

        public IEnumerable<ReviewViewModel> Reviews { get; set; }
    }
}
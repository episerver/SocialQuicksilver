using EPiServer.Reference.Social.Reviews.Composites;
using EPiServer.Reference.Social.Reviews.ViewModels;
using EPiServer.Social.Comments.Core;
using EPiServer.Social.Common;
using EPiServer.Social.Ratings.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EPiServer.Reference.Social.Reviews.Services
{
    internal static class ViewModelAdapter
    {
        public static ReviewStatisticsViewModel Adapt(RatingStatistics statistics)
        {
            var viewModel = new ReviewStatisticsViewModel();

            if (statistics != null)
            {
                viewModel.OverallRating = Convert.ToDouble(statistics.Sum) / Convert.ToDouble(statistics.TotalCount);
                viewModel.TotalRatings = statistics.TotalCount;
            }

            return viewModel;
        }

        public static IEnumerable<ReviewViewModel> Adapt(IEnumerable<Composite<Comment, Review>> reviews)
        {
            return reviews.Select(Adapt);
        }

        private static ReviewViewModel Adapt(Composite<Comment, Review> review)
        {
            return new ReviewViewModel
            {
                AddedOn = review.Data.Created,
                Body = review.Data.Body,
                Location = review.Extension.Location,
                Nickname = review.Extension.Nickname,
                Rating = review.Extension.Rating.Value,
                Title = review.Extension.Title
            };
        }
    }
}

using EPiServer.Reference.Social.Reviews.Composites;
using EPiServer.Reference.Social.Reviews.ViewModels;
using EPiServer.ServiceLocation;
using EPiServer.Social.Comments.Core;
using EPiServer.Social.Common;
using EPiServer.Social.Ratings.Core;
using System.Collections.Generic;
using System.Linq;

namespace EPiServer.Reference.Social.Reviews.Services
{
    /// <summary>
    /// The ReviewService manages reviews contributed for products by leveraging
    /// Episerver Social's comments and ratings features.
    /// </summary>
    [ServiceConfiguration(typeof(IReviewService), Lifecycle = ServiceInstanceScope.Singleton)]
    public class ReviewService : IReviewService
    {
        private readonly ICommentService commentService;
        private readonly IRatingService ratingService;
        private readonly IRatingStatisticsService statisticsService;
        private readonly CommentFilters commentFilters;
        private readonly RatingStatisticsFilters ratingStatisticsFilters;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="commentService">Episerver Social comment service</param>
        /// <param name="ratingService">Episerver Social rating service</param>
        public ReviewService(ICommentService commentService, IRatingService ratingService, IRatingStatisticsService statisticsService)
        {
            this.commentService = commentService;
            this.ratingService = ratingService;
            this.statisticsService = statisticsService;
            this.commentFilters = new CommentFilters();
            this.ratingStatisticsFilters = new RatingStatisticsFilters();
        }

        /// <summary>
        /// Adds a review for the identified product.
        /// </summary>
        /// <param name="productCode">Content code identifying the product being reviewed</param>
        /// <param name="review">Review to be added</param>
        public void Add(ReviewSubmissionViewModel review)
        {
            // Instantiate a reference for the product

            var product = CreateProductReference(review.ProductCode);

            // Instantiate a reference for the contributor

            var contributor = CreateContributorReference(review.Nickname);

            // Add the contributor's rating for the product

            var submittedRating = new Rating(contributor, product, new RatingValue(review.Rating));
            var storedRating = this.ratingService.Add(submittedRating);

            // Compose a comment representing the review

            var comment = new Comment(product, contributor, review.Body, true);

            var extension = new Review
            {
                Title = review.Title,
                Location = review.Location,
                Nickname = review.Nickname,
                Rating = new ReviewRating
                {
                    Value = review.Rating,
                    Reference = storedRating.Id.Id
                }
            };

            // Add the composite comment for the product

            this.commentService.Add(comment, extension);
        }

        /// <summary>
        /// Gets the reviews that have been submitted for the identified product.
        /// </summary>
        /// <param name="productCode">Content code identifying the product</param>
        /// <returns>Reviews that have been submitted for the product</returns>
        public ReviewsViewModel Get(string productCode)
        {
            var product = CreateProductReference(productCode);
            
            var statistics = this.GetProductStatistics(product);
            var reviews = this.GetProductReviews(product);

            return new ReviewsViewModel
            {
                Statistics = ViewModelAdapter.Adapt(statistics),
                Reviews = ViewModelAdapter.Adapt(reviews)
            };            
        }

        /// <summary>
        /// Gets the rating statistics for the identified product
        /// </summary>
        /// <param name="product">Reference identifying the product</param>
        /// <returns>Rating statistics for the product</returns>
        private RatingStatistics GetProductStatistics(EPiServer.Social.Common.Reference product)
        {
            var statisticsCriteria = new Criteria
            {
                Filter = this.ratingStatisticsFilters.Target.EqualTo(product),
                PageInfo = new PageInfo()
                {
                     PageSize = 1
                }
            };

            return this.statisticsService.Get(statisticsCriteria).Results.FirstOrDefault();
        }

        /// <summary>
        /// Gets a collection of reviews for the identified product.
        /// </summary>
        /// <param name="product">Reference identifying the product</param>
        /// <returns>Collection of reviews for the product</returns>
        private IEnumerable<Comment<Review>> GetProductReviews(EPiServer.Social.Common.Reference product)
        {
            var filters = new List<FilterExpression>();
            filters.Add(this.commentFilters.Parent.EqualTo(product));
            filters.Add(this.commentFilters.Extension.Type.Is<Review>());

            var commentCriteria = new Criteria
            {
                Filter = new AndExpression(filters),
                PageInfo = new PageInfo
                {
                     PageSize = 20
                },
                OrderBy = new List<SortInfo>
                {
                    new SortInfo(CommentSortFields.Created, false)                    
                }
            };

            return this.commentService.Get<Review>(commentCriteria).Results;
        }

        /// <summary>
        /// Creates a reference identifying a review contributor.
        /// </summary>
        /// <param name="nickname">Nickname identifying the review contributor</param>
        /// <returns>Reference identifying a review contributor</returns>
        private static EPiServer.Social.Common.Reference CreateContributorReference(string nickname)
        {
            return EPiServer.Social.Common.Reference.Create($"visitor://{nickname}");
        }

        /// <summary>
        /// Creates a reference identifying a product.
        /// </summary>
        /// <param name="nickname">Content code identifying the product</param>
        /// <returns>Reference identifying a product</returns>
        private static EPiServer.Social.Common.Reference CreateProductReference(string productCode)
        {
            return EPiServer.Social.Common.Reference.Create($"product://{productCode}");
        }
    }
}
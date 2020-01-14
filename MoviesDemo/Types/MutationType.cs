using System;
using HotChocolate.Types;
using MoviesDemo.Models;
using MoviesDemo.Services;

namespace MoviesDemo.Types
{
    public class ReviewInputType : InputObjectType<Review>
    {
    }

    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(t => t.CreateReview(default, default))
                .Type<NonNullType<ReviewType>>()
                .Argument("movieId", a => a.Type<NonNullType<IdType>>())
                .Argument("review", a => a.Type<NonNullType<ReviewInputType>>());
        }
    }

    public class Mutation
    {
        private readonly IReviewService _reviewService;

        public Mutation(IReviewService reviewService)
        {
            _reviewService = reviewService ?? throw new ArgumentNullException(nameof(reviewService));
        }

        public Review CreateReview(string movieId, Review review)
        {
            review.MovieId = movieId;
            _reviewService.Create(review);
            return review;
        }
    }
}

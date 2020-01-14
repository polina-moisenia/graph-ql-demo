using System;
using MoviesDemo.Models;
using MoviesDemo.Services;
using HotChocolate;
using System.Linq;

namespace MoviesDemo.Resolvers
{
    public class ReviewResolver
    {
        private readonly IReviewService _reviewService;
        public ReviewResolver(IReviewService service)
        {
            _reviewService = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IQueryable<Review> GetReviewsByMovieId([Parent]Movie movie) => _reviewService.GetReviewsByMovieId(movie.MovieId).AsQueryable();
    }
}

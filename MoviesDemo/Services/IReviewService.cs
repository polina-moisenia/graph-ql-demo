using System.Collections.Generic;
using MoviesDemo.Models;

namespace MoviesDemo.Services
{
    public interface IReviewService
    {
        List<Review> GetAll();
        List<Review> GetReviewsByMovieId(string movieId);
        Review GetByReviewId(string reviewId);
        Review Create(Review movie);
        void Update(string id, Review movieIn);
        void Remove(string id);
    }
}
using System.Collections.Generic;
using Reviews.Models;

namespace Reviews.Services
{
    public interface IReviewsService
    {
        List<Review> Get();
        Review Get(string id);
        List<Review> GetByMovieId(string movieId);
        Review Create(Review Review);
        void Update(string id, Review UsageIn);
        void Remove(string id);
    }
}
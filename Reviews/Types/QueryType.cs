using HotChocolate.Types;
using System;
using System.Linq;
using Reviews.Models;
using Reviews.Services;

namespace Reviews.Types
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetReviews()).Name("all_reviews");
            descriptor.Field(t => t.GetReviewsForMovie(default)).Name("reviews").Argument("movieId", a => a.Type<IdType>());
        }
    }

    public class Query
    {
        private readonly IReviewsService _service;

        public Query(IReviewsService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IQueryable<Review> GetReviews() => _service.Get().AsQueryable();
        public IQueryable<Review> GetReviewsForMovie(string movieId) => _service.GetByMovieId(movieId).AsQueryable();
    }
}
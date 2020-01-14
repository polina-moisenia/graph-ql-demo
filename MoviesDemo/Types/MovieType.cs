using MoviesDemo.Models;
using MoviesDemo.Resolvers;
using HotChocolate.Types;
using MoviesDemo.Services;
using System;

namespace MoviesDemo.Types
{
    public class MovieType : ObjectType<Movie>
    {
        private readonly IReviewService _reviewService;

        public MovieType(IReviewService service)
        {
            _reviewService = service ?? throw new ArgumentNullException(nameof(service));
        }

        protected override void Configure(IObjectTypeDescriptor<Movie> descriptor)
        {
            descriptor.Field(t => t.MovieId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Title)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Year)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Genres)
                .Type<ListType<EnumType<Genre>>>();

            descriptor.Field<RateResolver>(t => t.GetRate(default, default))
                .Type<StringType>()
                .Argument("source", a => a.Type<EnumType<RateSource>>())
                .Name("rate");

            descriptor.Field<ReviewResolver>(t => t.GetReviewsByMovieId(default))
                .Type<ListType<ReviewType>>()
                .Name("reviews");
        }        
    }
}

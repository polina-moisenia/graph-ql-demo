using MoviesDemo.Models;
using MoviesDemo.Resolvers;
using HotChocolate.Types;

namespace MoviesDemo.Types
{
    public class MovieType : ObjectType<Movie>
    {
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
        }        
    }
}

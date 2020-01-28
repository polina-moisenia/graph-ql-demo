using MoviesDemo.Models;
using MoviesDemo.Resolvers;
using HotChocolate.Types;

namespace MoviesDemo.Types
{
    // public class ReviewType : ObjectType<Review>
    // {
    //     protected override void Configure(IObjectTypeDescriptor<Review> descriptor)
    //     {
    //         descriptor.Field(t => t.MovieId)
    //             .Type<NonNullType<IdType>>();

    //         descriptor.Field(t => t.ReviewId)
    //             .Type<NonNullType<IdType>>();

    //         descriptor.Field(t => t.ReviewText)
    //             .Type<NonNullType<StringType>>();

    //         descriptor.Field(t => t.Rate)
    //             .Type<NonNullType<IntType>>();
                
    //         descriptor.Field(t => t.AuthorId)
    //             .Type<NonNullType<IdType>>();
    //     }
    // }
}

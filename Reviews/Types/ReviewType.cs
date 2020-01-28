using Reviews.Models;
using HotChocolate.Types;
using Reviews.Services;
using System;
using Reviews.Resolvers;

namespace Reviews.Types
{
    public class ReviewType : ObjectType<Review>
    {
        protected override void Configure(IObjectTypeDescriptor<Review> descriptor)
        {
            descriptor.Field(t => t.ReviewId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.MovieId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.AuthorId)
                .Type<NonNullType<IdType>>();

            descriptor.Field<UserResolver>(t => t.GetUserById(default))
                .Type<NonNullType<UserType>>()
                .Name("user");
        }
    }
}

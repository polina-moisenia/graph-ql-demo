using UsageHistory.Models;
using UsageHistory.Resolvers;
using HotChocolate.Types;

namespace UsageHistory.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(t => t.UsageId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.UserText)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Rate)
                .Type<NonNullType<IntType>>();
                
            descriptor.Field(t => t.AuthorId)
                .Type<NonNullType<IdType>>();
        }
    }
}

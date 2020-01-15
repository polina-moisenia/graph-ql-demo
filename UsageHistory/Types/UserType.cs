using UsageHistory.Models;
using UsageHistory.Resolvers;
using HotChocolate.Types;

namespace UsageHistory.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(t => t.UserId)
                .Type<NonNullType<IdType>>();

            descriptor.Field(t => t.Name)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.Surname)
                .Type<NonNullType<StringType>>();
                
            descriptor.Field(t => t.DOB)
                .Name("DateOfBirth")
                .Type<NonNullType<StringType>>();
        }
    }
}

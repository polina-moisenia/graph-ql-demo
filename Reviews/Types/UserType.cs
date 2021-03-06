using Reviews.Models;
using Reviews.Resolvers;
using HotChocolate.Types;

namespace Reviews.Types
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
                .Name("dateOfBirth")
                .Type<NonNullType<StringType>>();
        }
    }
}

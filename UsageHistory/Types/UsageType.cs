using UsageHistory.Models;
using UsageHistory.Resolvers;
using HotChocolate.Types;
using UsageHistory.Services;
using System;

namespace UsageHistory.Types
{
    public class UsageType : ObjectType<Usage>
    {
        private readonly IUsersService _UsersService;

        public UsageType(IUsersService service)
        {
            _UsersService = service ?? throw new ArgumentNullException(nameof(service));
        }

        protected override void Configure(IObjectTypeDescriptor<Usage> descriptor)
        {
            descriptor.Field(t => t.UsageId)
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

            descriptor.Field<UserResolver>(t => t.GetUsersByUsageId(default))
                .Type<ListType<UserType>>()
                .Name("Users");
        }        
    }
}

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

            descriptor.Field(t => t.UserId)
                .Type<NonNullType<StringType>>();

            descriptor.Field(t => t.MovieId)
                .Type<NonNullType<StringType>>();
        }        
    }
}

using System;
using HotChocolate.Types;
using UsageHistory.Models;
using UsageHistory.Services;

namespace UsageHistory.Types
{
    public class UserInputType : InputObjectType<User>
    {
    }

    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(t => t.CreateUser(default, default))
                .Type<NonNullType<UserType>>()
                .Argument("usageId", a => a.Type<NonNullType<IdType>>())
                .Argument("user", a => a.Type<NonNullType<UserInputType>>());
        }
    }

    public class Mutation
    {
        private readonly IUsersService _usersService;

        public Mutation(IUsersService usersService)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        public User CreateUser(string usageId, User user)
        {
            user.UsageId = usageId;
            _usersService.Create(user);
            return user;
        }
    }
}

using HotChocolate;
using System;
using System.Linq;
using UsageHistory.Models;
using UsageHistory.Services;

namespace UsageHistory.Resolvers
{
    public class UserResolver
    {
        private readonly IUsersService _usersService;
        public UserResolver(IUsersService service)
        {
            _usersService = service ?? throw new ArgumentNullException(nameof(service));
        }
    }
}

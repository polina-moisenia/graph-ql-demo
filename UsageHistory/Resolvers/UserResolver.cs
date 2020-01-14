using System;
using UsageHistory.Models;
using UsageHistory.Services;
using System.Linq;

namespace UsageHistory.Resolvers
{
    public class UserResolver
    {
        private readonly IUsersService _usersService;
        public UserResolver(IUsersService service)
        {
            _usersService = service ?? throw new ArgumentNullException(nameof(service));
        }

        public IQueryable<User> GetUsersByUsageId([Parent]Usage Usage) => _usersService.GetUsersByUsageId(Usage.UsageId).AsQueryable();
    }
}

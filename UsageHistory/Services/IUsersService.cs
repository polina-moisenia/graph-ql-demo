using System.Collections.Generic;
using UsageHistory.Models;

namespace UsageHistory.Services
{
    public interface IUsersService
    {
        List<User> Get();
        User Get(string userId);
        User Create(User user);
        void Update(string id, User userIn);
        void Remove(string id);
    }
}
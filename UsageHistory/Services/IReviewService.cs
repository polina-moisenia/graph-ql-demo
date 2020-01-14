using System.Collections.Generic;
using UsageHistory.Models;

namespace UsageHistory.Services
{
    public interface IUsersService
    {
        List<User> GetAll();
        List<User> GetUsersByUsageId(string UsageId);
        User GetByUserId(string UserId);
        User Create(User Usage);
        void Update(string id, User UsageIn);
        void Remove(string id);
    }
}
using System.Collections.Generic;
using System.Linq;
using UsageHistory.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace UsageHistory.Services
{
    public class UsersService : IUsersService
    {
        private readonly IMongoCollection<User> _Users;

        public UsersService(IOptions<DatabaseConfiguration> config)
        {
            var configMongo = config.Value;
            var client = new MongoClient(configMongo.ConnectionString);
            var database = client.GetDatabase(configMongo.DatabaseName);

            _Users = database.GetCollection<User>(configMongo.UsersCollectionName);
        }

        public List<User> GetAll()
        {
            Console.WriteLine("The request to the mongo DB for all Users is done");
            return _Users.Find(User => true).ToList();
        }
        public List<User> GetUsersByUsageId(string UsageId)
        {
            Console.WriteLine($"The request to the mongo DB for User of the Usage {UsageId} is done");
            return _Users.Find<User>(User => User.UsageId == UsageId).ToList();
        }
        public User GetByUserId(string UserId) => _Users.Find<User>(User => User.UserId == UserId).FirstOrDefault();

        public User Create(User User)
        {
            _Users.InsertOne(User);
            return User;
        }

        public void Update(string id, User UserIn) => _Users.ReplaceOne(User => User.UserId == id, UserIn);
        public void Remove(string id) => _Users.DeleteOne(User => User.UserId == id);
    }
}
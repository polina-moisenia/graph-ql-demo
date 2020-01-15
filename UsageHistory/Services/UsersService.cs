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
        private readonly IMongoCollection<User> _users;

        public UsersService(IOptions<DatabaseConfiguration> config)
        {
            var configMongo = config.Value;
            var client = new MongoClient(configMongo.ConnectionString);
            var database = client.GetDatabase(configMongo.DatabaseName);

            _users = database.GetCollection<User>(configMongo.UsersCollectionName);
        }

        public List<User> Get()
        {
            Console.WriteLine("The request to the mongo DB for all Users is done");
            return _users.Find(User => true).ToList();
        }
        
        public User Get(string userId) => _users.Find<User>(user => user.UserId == userId).FirstOrDefault();

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) => _users.ReplaceOne(user => user.UserId == id, userIn);
        public void Remove(string id) => _users.DeleteOne(user => user.UserId == id);
    }
}
using System.Collections.Generic;
using System.Linq;
using UsageHistory.Models;
using UsageHistory.Types;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace UsageHistory.Services
{
    public class UsagesService : IUsagesService
    {
        private readonly IMongoCollection<Usage> _usages;

        public UsagesService(IOptions<DatabaseConfiguration> config)
        {
            var configMongo = config.Value;
            var client = new MongoClient(configMongo.ConnectionString);
            var database = client.GetDatabase(configMongo.DatabaseName);

            _usages = database.GetCollection<Usage>(configMongo.UsagesCollectionName);
        }

        public List<Usage> Get()
        {
            Console.WriteLine("The request to the mongo DB for all Usages is done");
            return _usages.Find(Usage => true).ToList();
        }
        public Usage Get(string id) {
            Console.WriteLine($"The request to the mongo DB for Usage {id} is done");
            return _usages.Find<Usage>(Usage => Usage.UsageId == id).FirstOrDefault();
        }

        public Usage Create(Usage usage)
        {
            _usages.InsertOne(usage);
            return usage;
        }

        public void Update(string id, Usage usageIn) => _usages.ReplaceOne(usage => usage.UsageId == id, usageIn);
        public void Remove(string id) => _usages.DeleteOne(usage => usage.UsageId == id);
    }
}
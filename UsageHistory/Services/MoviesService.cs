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
        private readonly IMongoCollection<Usage> _Usages;

        public UsagesService(IOptions<DatabaseConfiguration> config)
        {
            var configMongo = config.Value;
            var client = new MongoClient(configMongo.ConnectionString);
            var database = client.GetDatabase(configMongo.DatabaseName);

            _Usages = database.GetCollection<Usage>(configMongo.UsagesCollectionName);
        }

        public List<Usage> Get()
        {
            Console.WriteLine("The request to the mongo DB for all Usages is done");
            return _Usages.Find(Usage => true).ToList();
        }
        public Usage Get(string id) {
            Console.WriteLine($"The request to the mongo DB for Usage {id} is done");
            return _Usages.Find<Usage>(Usage => Usage.UsageId == id).FirstOrDefault();
        }

        public Usage Create(Usage Usage)
        {
            _Usages.InsertOne(Usage);
            return Usage;
        }

        public void Update(string id, Usage UsageIn) => _Usages.ReplaceOne(Usage => Usage.UsageId == id, UsageIn);
        public void Remove(string id) => _Usages.DeleteOne(Usage => Usage.UsageId == id);
    }
}
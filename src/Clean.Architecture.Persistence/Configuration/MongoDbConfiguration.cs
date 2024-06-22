
using Clean.Architecture.Application.Settings;
using Clean.Architecture.Domain.DataBase;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Clean.Architecture.Persistence.Configuration
{
    public class MongoDbConfiguration
    {
        private readonly IMongoDatabase _database;

        public MongoDbConfiguration(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<T> GetCollection<T>(string name) where T : IEntity 
        {
            return _database.GetCollection<T>(name);
        }
    }
}

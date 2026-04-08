using MongoDB.Driver;
using RealEstateMediaPlatform.API.Configurations;
using Microsoft.Extensions.Options;
using RealEstateMediaPlatform.API.Models;

namespace RealEstateMediaPlatform.API.Data
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoClient client, IOptions<MongoDbSettings> settings)
        {
            _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<UserActivityLog> UserActivityLogs =>
            _database.GetCollection<UserActivityLog>("UserActivityLogs");

        public IMongoCollection<CaseHistory> CaseHistories =>
            _database.GetCollection<CaseHistory>("CaseHistories");
    }
}
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealEstateMediaPlatform.API.Configurations;
using RealEstateMediaPlatform.API.Data;
using Microsoft.Extensions.Options;

namespace RealEstateMediaPlatform.API.Extensions
{
    public static class MongoServiceExtensions
    {
        public static IServiceCollection AddMongo(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoDbSettings>(
                config.GetSection("MongoDb"));

            var settings = config.GetSection("MongoDb").Get<MongoDbSettings>();

            if (settings == null)
                throw new Exception("MongoDb settings not configured");

            services.AddSingleton<IMongoClient>(_ =>
                new MongoClient(settings.ConnectionString));

            services.AddSingleton<IMongoDatabase>(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(settings.Database);
            });

            services.AddSingleton<MongoDbContext>();

            return services;
        }
    }
}
using MongoDB.Driver;
using RealEstateMediaPlatform.API.Models;

namespace RealEstateMediaPlatform.API.Data;

public class ListingCaseHistoryRepository
{
    private readonly IMongoCollection<ListingCaseHistory> _collection;

    public ListingCaseHistoryRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<ListingCaseHistory>("ListingCaseHistory");
    }

    public async Task InsertAsync(ListingCaseHistory history)
    {
        await _collection.InsertOneAsync(history);
    }
}
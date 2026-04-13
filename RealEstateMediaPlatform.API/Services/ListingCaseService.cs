using AutoMapper;
using RealEstateMediaPlatform.API.Data;
using RealEstateMediaPlatform.API.DTOs;
using RealEstateMediaPlatform.API.Models;
namespace RealEstateMediaPlatform.API.Services;

public class ListingCaseService
{
    private readonly AppDbContext _context;
    private readonly ListingCaseHistoryRepository _historyRepo;

    public ListingCaseService(
        AppDbContext context,
        ListingCaseHistoryRepository historyRepo)
    {
        _context = context;
        _historyRepo = historyRepo;
    }

    public async Task<string> CreateAsync(CreateListingCaseDto dto, string userId)
    {
        var entity = new ListingCase
        {
            Title = dto.Title,
            Address = dto.Address,
            Bedrooms = dto.Bedrooms,
            Price = dto.Price,
            AgentId = userId,
            CreatedAt = DateTime.UtcNow
        };

        _context.ListingCases.Add(entity);
        await _context.SaveChangesAsync();

        var history = new ListingCaseHistory
        {
            ListingCaseId = entity.Id,
            Action = "Created",
            PerformedBy = userId,
            DataSnapshot = System.Text.Json.JsonSerializer.Serialize(entity),
            CreatedAt = DateTime.UtcNow
        };

        await _historyRepo.InsertAsync(history);

        return entity.Id.ToString();
    }
    public async Task<ListingCaseDto?> GetByIdAsync(int id)
    {
        var entity = await _context.ListingCases.FindAsync(id);

        if (entity == null)
            return null;

        return new ListingCaseDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Address = entity.Address,
            Bedrooms = entity.Bedrooms,
            Price = entity.Price,
            AgentId = entity.AgentId,
            CreatedAt = entity.CreatedAt
        };
    }
}
using AutoMapper;
using RealEstateMediaPlatform.API.Data;
using RealEstateMediaPlatform.API.DTOs;
using RealEstateMediaPlatform.API.Models;
namespace RealEstateMediaPlatform.API.Services;

using Microsoft.EntityFrameworkCore;
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
            Status = dto.PropertyStatus,
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
            Status = entity.Status,
            CreatedAt = entity.CreatedAt
        };
    }
    public async Task<List<ListingCaseDto>> GetAllAsync(string userId)
    {
        var list = await _context.ListingCases
            .Where(x => x.AgentId == userId)
            .ToListAsync();

        return list.Select(x => new ListingCaseDto
        {
            Id = x.Id,
            Title = x.Title,
            Address = x.Address,
            Bedrooms = x.Bedrooms,
            Price = x.Price,
            AgentId = x.AgentId,
            Status = x.Status,
            CreatedAt = x.CreatedAt
        }).ToList();
    }
    public async Task<bool> UpdateAsync(int id, UpdateListingCaseDto dto, string userId)
    {
        var entity = await _context.ListingCases
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            return false;

        if (entity.AgentId != userId)
            return false;

        entity.Title = dto.Title;
        entity.Address = dto.Address;
        entity.Bedrooms = dto.Bedrooms;
        entity.Price = dto.Price;
        entity.Status = dto.PropertyStatus;
        entity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> DeleteAsync(int id, string userId)
    {
        var entity = await _context.ListingCases
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            return false;

        if (entity.AgentId != userId)
            return false;

        _context.ListingCases.Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }
    public async Task<bool> UpdatePropertyStatusAsync(int id, PropertyStatus propertyStatus, string userId)
    {
        var entity = await _context.ListingCases
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            return false;

        if (entity.AgentId != userId)
            return false;

        entity.Status = propertyStatus;
        entity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }
}
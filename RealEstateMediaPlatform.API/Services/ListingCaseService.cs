using AutoMapper;
using RealEstateMediaPlatform.API.Data;
using RealEstateMediaPlatform.API.DTOs;
using RealEstateMediaPlatform.API.Models;
namespace RealEstateMediaPlatform.API.Services;

public class ListingCaseService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;
    private readonly ListingCaseHistoryRepository _historyRepo;

    public ListingCaseService(
        AppDbContext context,
        IMapper mapper,
        ListingCaseHistoryRepository historyRepo)
    {
        _context = context;
        _mapper = mapper;
        _historyRepo = historyRepo;
    }

    public async Task CreateAsync(CreateListingCaseDto dto, string userId)
    {
        var entity = _mapper.Map<ListingCase>(dto);

        _context.ListingCases.Add(entity);
        await _context.SaveChangesAsync();

        // ⭐ 审计日志（Mongo）
        var history = new ListingCaseHistory
        {
            ListingCaseId = entity.Id,
            Action = "Created",
            PerformedBy = userId,
            DataSnapshot = System.Text.Json.JsonSerializer.Serialize(entity)
        };

        await _historyRepo.InsertAsync(history);
    }
}
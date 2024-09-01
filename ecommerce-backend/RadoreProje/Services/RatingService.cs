using RadoreProje.Data;
using RadoreProje.Models;
using Microsoft.EntityFrameworkCore;
using RadoreProje.Dto;
using AutoMapper;

public class RatingService
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public RatingService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RatingDto>> GetAllRatingsAsync()
    {
        return await _context.Ratings
            .Select(r => _mapper.Map<RatingDto>(r))
            .ToListAsync();
    }

    public async Task<RatingDto?> GetRatingByIdAsync(int id)
    {
        var rating = await _context.Ratings.FindAsync(id);
        return rating != null ? _mapper.Map<RatingDto>(rating) : null;
    }

    public async Task<RatingDto> CreateRatingAsync(RatingDto ratingDto)
    {
        var rating = _mapper.Map<Rating>(ratingDto);
        _context.Ratings.Add(rating);
        await _context.SaveChangesAsync();

        return _mapper.Map<RatingDto>(rating);
    }

    public async Task<bool> UpdateRatingAsync(RatingDto ratingDto)
    {
        var rating = await _context.Ratings.FindAsync(ratingDto.Id);
        if (rating == null)
        {
            return false;
        }

        _mapper.Map(ratingDto, rating);
        _context.Entry(rating).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteRatingAsync(int id)
    {
        var rating = await _context.Ratings.FindAsync(id);
        if (rating == null)
        {
            return false;
        }

        _context.Ratings.Remove(rating);
        await _context.SaveChangesAsync();

        return true;
    }
}
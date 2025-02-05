using AutoMapper;
using DishesHub.Api.DAL;
using DishesHub.Api.DAL.Entities;
using DishesHub.Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace DishesHub.Api.BLL;

class RateService : IRateService
{
    private readonly DishesHubDbContext _dbContext;
    private readonly IMapper _mapper;
    public RateService(DishesHubDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task AddRate(RatePostDto ratePostDto)
    {
        var rate = _mapper.Map<Rate>(ratePostDto);
        var existedRate = await _dbContext.Rates.FirstOrDefaultAsync(r => r.RecipeId == rate.RecipeId && r.UserId == rate.UserId);
        if (existedRate == null)
        {
            await _dbContext.Rates.AddAsync(rate);
        }
        else
        {
            existedRate.Rating = rate.Rating;
            existedRate.Comment = rate.Comment;
        }
        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<RateGetDto> GetAllRatesForRecipeId(int id)
    {
        return _dbContext.Rates
            .Where(r => r.RecipeId == id)
            .Include(r => r.Author)
            .Select(r => new RateGetDto()
            {
                Comment = r.Comment, 
                Rating = r.Rating, 
                RecipeId = r.RecipeId,
                UserName = r.Author.UserName
            });
    }
}
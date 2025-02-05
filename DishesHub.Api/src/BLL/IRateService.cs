using DishesHub.Api.DTO;

namespace DishesHub.Api.BLL;

public interface IRateService
{
    public Task AddRate(RatePostDto ratePostDto);
    public IEnumerable<RateGetDto> GetAllRatesForRecipeId(int id);
}
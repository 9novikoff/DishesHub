using DishesHub.Api.DAL;
using DishesHub.Api.DAL.Entities;

namespace DishesHub.Api.BLL;

class IngredientService : IIngredientService
{
    private readonly DishesHubDbContext _dbContext;

    public IngredientService(DishesHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Ingredient> GetAllIngredients()
    {
        return _dbContext.Ingredients;
    }

    public IEnumerable<Ingredient> GetIngredientPage(int page, int size)
    {
        return _dbContext.Ingredients.Skip((page - 1) * size).Take(size);
    }
}
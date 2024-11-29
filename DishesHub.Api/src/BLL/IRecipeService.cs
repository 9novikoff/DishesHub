using DishesHub.Api.DAL.Entities;
using DishesHub.Api.DTO;

namespace DishesHub.Api.BLL;

public interface IRecipeService
{
    Task<IEnumerable<Recipe>> GetRecipesByUserAsync(string userId);
    Task<IEnumerable<Recipe>> GetMatchingRecipesAsync(IngredientsRequest request);
    Task<IEnumerable<Recipe>> GetMatchingRecipePageAsync(IngredientsRequest request, int page, int size);
    Task<Recipe> GetRecipeByIdAsync(int id);
    Task AddRecipeAsync(RecipeDto recipe, string userId);
    DetailedRecipeDto GetDetailedRecipesById(int id);
}
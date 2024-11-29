using DishesHub.Api.DAL;
using DishesHub.Api.DAL.Entities;
using DishesHub.Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace DishesHub.Api.BLL;

public class RecipeService : IRecipeService
{
    private readonly DishesHubDbContext _dbContext;

    public RecipeService(DishesHubDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Recipe>> GetRecipesByUserAsync(string userId)
    {
        return await _dbContext.Recipes.Where(r => r.Author.Id == userId).ToListAsync();
    }

    public async Task<IEnumerable<Recipe>> GetMatchingRecipesAsync(IngredientsRequest request)
    {
        return await _dbContext.Recipes
            .Where(r =>
                request.MatchIngredientIds.All(i => r.Ingredients.Select(ing => ing.Id).Contains(i)) &&
                !r.Ingredients.Any(i => request.AvoidIngredientIds.Contains(i.Id))
            )
            .OrderByDescending(r => r.Rates.Sum(rate => rate.Rating))
            .ToListAsync();
    }

    public async Task<IEnumerable<Recipe>> GetMatchingRecipePageAsync(IngredientsRequest request, int page, int size)
    {
        var all = await GetMatchingRecipesAsync(request);
        return all.Skip((page - 1) * size).Take(size);
    }

    public async Task<Recipe> GetRecipeByIdAsync(int id)
    {
        return await _dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task AddRecipeAsync(RecipeDto recipeDto, string userId)
    {
        var recipe = new Recipe
        {
            Name = recipeDto.Name,
            DishId = recipeDto.DishId,
            Description = recipeDto.Description,
            VideoRefference = recipeDto.VideoRefference,
            AuthorId = userId,
            Ingredients = recipeDto.Ingredients.Select(i => _dbContext.Ingredients.Find(i.Id)).ToList(),
            Picture = recipeDto.Picture
        };
        
        await _dbContext.Recipes.AddAsync(recipe);
        await _dbContext.SaveChangesAsync();
    }
    
    public DetailedRecipeDto GetDetailedRecipesById(int id)
    {
        var recipe = _dbContext.Recipes.Include(r => r.Ingredients).Include(recipe => recipe.Author).Single(r => r.Id == id);
        return new DetailedRecipeDto {Id = recipe.Id, Description = recipe.Description, VideoRefference = recipe.VideoRefference, Ingredients = recipe.Ingredients.Select(i => new IngredientDto() {Id = i.Id, Name = i.Name}).ToList(), Name = recipe.Name, Picture = recipe.Picture, AuthorEmail = recipe.Author.Email};
    }
}

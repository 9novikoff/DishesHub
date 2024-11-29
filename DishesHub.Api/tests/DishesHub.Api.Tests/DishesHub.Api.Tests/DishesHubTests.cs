using DishesHub.Api.BLL;
using DishesHub.Api.DAL;
using DishesHub.Api.DAL.Entities;
using DishesHub.Api.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DishesHub.Api.Tests;


public class DishesHubTests
{
    [Fact]
    public async Task GetRecipesByUserAsync_ReturnsRecipesForGivenUserId()
    {
        var options = new DbContextOptionsBuilder<DishesHubDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        await using var context = new DishesHubDbContext(options);
        context.Users.Add(new IdentityUser() { Id = "user1", Email = "user1@example.com" });
        context.Recipes.AddRange(
            new Recipe { Id = 1, Name = "Recipe 1", AuthorId = "user1", Description = "Description1" },
            new Recipe { Id = 2, Name = "Recipe 2", AuthorId = "user2", Description = "Description2" }
        );
        await context.SaveChangesAsync();

        var service = new RecipeService(context);
        
        var result = await service.GetRecipesByUserAsync("user1");
        
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Recipe 1", result.First().Name);
    }

    [Fact]
    public async Task AddRecipeAsync_AddsRecipeSuccessfully()
    {
        var options = new DbContextOptionsBuilder<DishesHubDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase3")
            .Options;

        await using var context = new DishesHubDbContext(options);
        context.Ingredients.Add(new Ingredient { Id = 1, Name = "Ingredient 1" });
        await context.SaveChangesAsync();

        var service = new RecipeService(context);
        var recipeDto = new RecipeDto
        {
            Name = "New Recipe",
            DishId = 1,
            Description = "A test recipe",
            Ingredients = new List<IngredientDto> { new IngredientDto { Id = 1, Name = "Ingredient 1" } },
            Picture = "Base64Image",
            VideoRefference = "https://example.com/video"
        };
        
        await service.AddRecipeAsync(recipeDto, "user1");
        
        var addedRecipe = context.Recipes.Include(r => r.Ingredients).FirstOrDefault();
        Assert.NotNull(addedRecipe);
        Assert.Equal("New Recipe", addedRecipe.Name);
        Assert.Single(addedRecipe.Ingredients);
        Assert.Equal("Ingredient 1", addedRecipe.Ingredients.First().Name);
    }
}
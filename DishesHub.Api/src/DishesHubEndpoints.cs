using DishesHub.Api.BLL;
using DishesHub.Api.DAL;
using DishesHub.Api.DTO;
using Microsoft.EntityFrameworkCore;

namespace DishesHub.Api;

public static class DishesHubEndpoints
{
    public static IEndpointRouteBuilder MapApi(this IEndpointRouteBuilder app)
    {
        app.MapGet("/ingredients", (IIngredientService service) => service.GetAllIngredients());
        app.MapGet("/ingredient-page", (int page, int size, IIngredientService service) => service.GetIngredientPage(page, size));

        app.MapGet("{user}/recipes", async (string user, IRecipeService recipeService) =>
        {
            var recipes = await recipeService.GetRecipesByUserAsync(user);
            return recipes;
        });

        app.MapGet("/recipe/{id}", async (int id, IRecipeService recipeService) =>
            await recipeService.GetRecipeByIdAsync(id));
        
        app.MapGet("/detailed-recipe/{id}", (int id, IRecipeService recipeService) =>
            recipeService.GetDetailedRecipesById(id));

        app.MapPost("/recipe-matches", async (IngredientsRequest request, IRecipeService recipeService) =>
            await recipeService.GetMatchingRecipesAsync(request));         
        
        app.MapPost("/recipe-matches-page", async (int page, int size, IngredientsRequest request, IRecipeService recipeService) =>
            await recipeService.GetMatchingRecipePageAsync(request, page, size)); 

        app.MapPost("/recipe", async (RecipeDto recipe, IRecipeService recipeService, HttpContext httpContext) =>
                await recipeService.AddRecipeAsync(recipe, httpContext.User.Claims.First().Value))
            .RequireAuthorization();
        
        app.MapGet("/current-user", (HttpContext httpContext) => new {Id = httpContext.User.Claims.ToList()[0].Value, Email = httpContext.User.Claims.ToList()[1].Value});
        
        app.MapGet("/dishes", (DishesHubDbContext dbContext) => dbContext.Dishes);

        app.MapPost("/rate", async (HttpContext httpContext, RatePostDto rate, IRateService rateService) =>
        {
            rate.UserId = httpContext.User.Claims.ToList()[0].Value;
            await rateService.AddRate(rate);
            return Results.Ok();
        }).RequireAuthorization();
        
        app.MapGet("/rate/{id}", (int id, IRateService rateService) => rateService.GetAllRatesForRecipeId(id));
        
        return app;
    }
}
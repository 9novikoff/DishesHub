using DishesHub.Api.DAL;
using DishesHub.Api.DAL.Entities;
using DishesHub.Api.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DishesHub.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();

        builder.Services.AddDbContext<DishesHubDbContext>(o =>
            o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<DishesHubDbContext>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapIdentityApi<IdentityUser>();

        app.MapGet("/ingredients", (DishesHubDbContext dbContext) => dbContext.Ingredients);
        
        app.MapPost("/recipe-matches", (IngredientsRequest request, DishesHubDbContext dbContext, HttpContext httpContext) =>
            {
                return dbContext.Recipes.Where(r =>
                    r.Ingredients.All(i => request.MatchIngredientIds.Contains(i.Id)) &&
                    !r.Ingredients.Any(i => request.AvoidIngredientIds.Contains(i.Id))
                );
            })
            .WithName("MatchingRecipes")
            .WithOpenApi();
        
        app.MapPost("/recipes", (RecipeDto recipe, DishesHubDbContext dbContext, HttpContext httpContext) =>
            {
                dbContext.Recipes.Add(new Recipe
                {
                    Name = recipe.Name, DishId = recipe.DishId, Description = recipe.Description,
                    VideoRefference = recipe.VideoRefference, AuthorId = httpContext.User.Claims.ToList()[0].Value, Ingredients = recipe.Ingredients.Select(i => dbContext.Ingredients.Find(i)).ToList()!
                });
            })
            .WithName("PostRecipes")
            .WithOpenApi()
            .RequireAuthorization();

        app.Run();
    }
}
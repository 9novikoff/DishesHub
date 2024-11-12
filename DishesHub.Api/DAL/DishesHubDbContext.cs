using DishesHub.Api.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DishesHub.Api.DAL;

public class DishesHubDbContext : IdentityDbContext<IdentityUser>
{
    public DishesHubDbContext(DbContextOptions<DishesHubDbContext> options) :
        base(options)
    { }
    
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Rate> Rates { get; set; }
}
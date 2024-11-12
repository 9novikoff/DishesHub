using Microsoft.AspNetCore.Identity;

namespace DishesHub.Api.DAL.Entities;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AuthorId { get; set; }
    public string DishId { get; set; }
    public string Description { get; set; }
    public string? VideoRefference { get; set; }

    public IdentityUser Author { get; set; }
    public Dish Dish { get; set; }
    public List<Ingredient> Ingredients { get; set; }
}
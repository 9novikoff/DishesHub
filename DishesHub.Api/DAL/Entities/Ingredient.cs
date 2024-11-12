namespace DishesHub.Api.DAL.Entities;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte[] Picture { get; set; }
    
    public List<Recipe> Recipes { get; set; }
}
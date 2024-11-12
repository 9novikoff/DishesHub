namespace DishesHub.Api.DTO;

public class RecipeDto
{
    public string Name { get; set; }
    public string DishId { get; set; }
    public string Description { get; set; }
    public string? VideoRefference { get; set; }
    public List<int> Ingredients { get; set; }
}
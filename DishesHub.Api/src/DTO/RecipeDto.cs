namespace DishesHub.Api.DTO;

public class RecipeDto
{
    public string Name { get; set; }
    public string AuthorId { get; set; }
    public string? Picture { get; set; }
    public int DishId { get; set; }
    public string Description { get; set; }
    public string? VideoRefference { get; set; }
    public List<IngredientDto> Ingredients { get; set; }
}
using DishesHub.Api.DAL.Entities;

namespace DishesHub.Api.DTO;

public class DetailedRecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Picture { get; set; }
    public string AuthorEmail { get; set; }
    public string Description { get; set; }
    public string? VideoRefference { get; set; }
    public List<IngredientDto> Ingredients { get; set; }
}
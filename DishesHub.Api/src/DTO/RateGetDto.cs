namespace DishesHub.Api.DTO;

public class RateGetDto
{
    public string UserName { get; set; }
    public int RecipeId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}
namespace DishesHub.Api.DTO;

public class RatePostDto
{
    public string UserId { get; set; }
    public int RecipeId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}
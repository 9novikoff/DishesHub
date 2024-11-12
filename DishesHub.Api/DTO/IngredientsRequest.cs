namespace DishesHub.Api.DTO;

public class IngredientsRequest
{
    public List<int> MatchIngredientIds { get; set; }
    public List<int> AvoidIngredientIds { get; set; }
}
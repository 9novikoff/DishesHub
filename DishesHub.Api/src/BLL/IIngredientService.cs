using DishesHub.Api.DAL.Entities;

namespace DishesHub.Api.BLL;

public interface IIngredientService
{
    public IEnumerable<Ingredient> GetAllIngredients();
    public IEnumerable<Ingredient> GetIngredientPage(int page, int size);
    
}
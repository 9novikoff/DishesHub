using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DishesHub.Api.DAL.Entities;

public class Recipe
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string AuthorId { get; set; }
    public int DishId { get; set; }
    public string Description { get; set; }
    public string? VideoRefference { get; set; }
    public string? Picture { get; set; }

    public IdentityUser Author { get; set; }
    public Dish Dish { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<Rate> Rates { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DishesHub.Api.DAL.Entities;

public class Rate
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    public int Id { get; set; }
    [ForeignKey("Author")]
    public string UserId { get; set; }
    public int RecipeId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
        
    public virtual IdentityUser Author { get; set; }
    public virtual Recipe Recipe { get; set; }    
}
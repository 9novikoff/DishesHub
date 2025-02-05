using DishesHub.Api.BLL;
using DishesHub.Api.DAL;
using DishesHub.Api.DAL.Entities;
using DishesHub.Api.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DishesHub.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAutoMapper(typeof(MappingProfile));

        builder.Services.AddAuthorization();

        builder.Services.AddDbContext<DishesHubDbContext>(o =>
            o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
        
        builder.Services.AddScoped<IRecipeService, RecipeService>();
        builder.Services.AddScoped<IIngredientService, IngredientService>();
        builder.Services.AddScoped<IRateService, RateService>();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        builder.Services.AddIdentityApiEndpoints<IdentityUser>()
            .AddEntityFrameworkStores<DishesHubDbContext>();
        
        builder.Services.AddCors(corsOptions =>
        {
            corsOptions.AddPolicy("AllowAll", options =>
            {
                options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthorization();

        app.MapIdentityApi<IdentityUser>();
        
        app.MapApi();
        
        app.Run();
    }
}
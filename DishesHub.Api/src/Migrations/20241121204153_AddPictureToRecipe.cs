using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DishesHub.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPictureToRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Recipes",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Recipes");
        }
    }
}

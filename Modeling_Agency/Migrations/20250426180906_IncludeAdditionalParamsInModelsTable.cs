using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modeling_Agency.Migrations
{
    /// <inheritdoc />
    public partial class IncludeAdditionalParamsInModelsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Models",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Models",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "Models",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Models");
        }
    }
}

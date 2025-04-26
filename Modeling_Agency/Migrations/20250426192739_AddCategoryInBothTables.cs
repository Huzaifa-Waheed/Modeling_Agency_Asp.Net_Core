using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modeling_Agency.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryInBothTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Models",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "ModelApplications",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "ModelApplications");
        }
    }
}

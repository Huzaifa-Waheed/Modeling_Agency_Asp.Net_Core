using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modeling_Agency.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColAppliStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatus",
                table: "ModelApplications",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationStatus",
                table: "ModelApplications");
        }
    }
}

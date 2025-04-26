using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modeling_Agency.Migrations
{
    /// <inheritdoc />
    public partial class AddHireRecordsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HireRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HireRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HireRecords_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HireRecords_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HireRecords_ClientId",
                table: "HireRecords",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_HireRecords_ModelId",
                table: "HireRecords",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HireRecords");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tadas_SOA_Repeat_CA.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllCategories_Games_GameId",
                table: "AllCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AllCategories",
                table: "AllCategories");

            migrationBuilder.DropColumn(
                name: "Developer",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "AllCategories",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_AllCategories_GameId",
                table: "Categories",
                newName: "IX_Categories_GameId");

            migrationBuilder.AddColumn<int>(
                name: "DeveloperId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GameCategories",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameCategories", x => new { x.GameId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_GameCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameCategories_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "GameId", "category" },
                values: new object[,]
                {
                    { 1, null, "Platform" },
                    { 2, null, "Adventure" },
                    { 3, null, "Action" },
                    { 4, null, "Sandbox" },
                    { 5, null, "Survival" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "FoundationDate", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1889, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyoto, Japan", "Nintendo" },
                    { 2, new DateTime(2009, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stockholm, Sweden", "Mojang Studios" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "DeveloperId", "Name", "Owned", "Publisher", "RecordCreationDate", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 1, "Super Mario Bros.", true, "Nintendo", new DateTime(2023, 8, 11, 7, 21, 25, 582, DateTimeKind.Local).AddTicks(3499), new DateTime(1985, 9, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "The Legend of Zelda: Breath of the Wild", true, "Nintendo", new DateTime(2023, 8, 11, 7, 21, 25, 582, DateTimeKind.Local).AddTicks(3551), new DateTime(2017, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Minecraft", false, "Mojang", new DateTime(2023, 8, 11, 7, 21, 25, 582, DateTimeKind.Local).AddTicks(3554), new DateTime(2011, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "GameCategories",
                columns: new[] { "CategoryId", "GameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategories_CategoryId",
                table: "GameCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Games_GameId",
                table: "Categories",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Games_GameId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropTable(
                name: "GameCategories");

            migrationBuilder.DropIndex(
                name: "IX_Games_DeveloperId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DeveloperId",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "AllCategories");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_GameId",
                table: "AllCategories",
                newName: "IX_AllCategories_GameId");

            migrationBuilder.AddColumn<string>(
                name: "Developer",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AllCategories",
                table: "AllCategories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AllCategories_Games_GameId",
                table: "AllCategories",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}

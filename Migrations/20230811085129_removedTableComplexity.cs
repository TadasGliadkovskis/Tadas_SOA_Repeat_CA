using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tadas_SOA_Repeat_CA.Migrations
{
    /// <inheritdoc />
    public partial class removedTableComplexity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Games_GameId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "GameCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_GameId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Categories",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "CategoryGame",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    GamesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGame", x => new { x.CategoriesId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_CategoryGame_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryGame_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 9, 51, 29, 62, DateTimeKind.Local).AddTicks(3834));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 9, 51, 29, 62, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 9, 51, 29, 62, DateTimeKind.Local).AddTicks(3872));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryGame_GamesId",
                table: "CategoryGame",
                column: "GamesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryGame");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "category");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Categories",
                type: "int",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "GameId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "GameId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "GameId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "GameId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "GameId",
                value: null);

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

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 9, 33, 47, 16, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 9, 33, 47, 16, DateTimeKind.Local).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 9, 33, 47, 16, DateTimeKind.Local).AddTicks(8289));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GameId",
                table: "Categories",
                column: "GameId");

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
        }
    }
}

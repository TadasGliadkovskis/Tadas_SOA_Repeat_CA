using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tadas_SOA_Repeat_CA.Migrations
{
    /// <inheritdoc />
    public partial class MadeTablesSimpler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryGame");

            migrationBuilder.AddColumn<string>(
                name: "CategoriesJson",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CategoriesJson", "RecordCreationDate" },
                values: new object[] { "[\"Platform\",\"Action\"]", new DateTime(2023, 8, 11, 10, 20, 20, 913, DateTimeKind.Local).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CategoriesJson", "RecordCreationDate" },
                values: new object[] { "[\"Adventure\",\"Action\"]", new DateTime(2023, 8, 11, 10, 20, 20, 913, DateTimeKind.Local).AddTicks(8921) });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoriesJson", "RecordCreationDate" },
                values: new object[] { "[\"Sandbox\",\"Survival\"]", new DateTime(2023, 8, 11, 10, 20, 20, 913, DateTimeKind.Local).AddTicks(8938) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriesJson",
                table: "Games");

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
    }
}

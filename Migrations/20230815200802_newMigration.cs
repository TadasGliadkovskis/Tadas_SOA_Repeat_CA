using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tadas_SOA_Repeat_CA.Migrations
{
    /// <inheritdoc />
    public partial class newMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 15, 21, 8, 2, 559, DateTimeKind.Local).AddTicks(5252));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 15, 21, 8, 2, 559, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 15, 21, 8, 2, 559, DateTimeKind.Local).AddTicks(5356));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 15, 21, 3, 36, 858, DateTimeKind.Local).AddTicks(327));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 15, 21, 3, 36, 858, DateTimeKind.Local).AddTicks(387));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 15, 21, 3, 36, 858, DateTimeKind.Local).AddTicks(446));
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tadas_SOA_Repeat_CA.Migrations
{
    /// <inheritdoc />
    public partial class updatedDeveloper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundationDate",
                table: "Developers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Developers");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 8, 7, 4, 30, DateTimeKind.Local).AddTicks(9726));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 8, 7, 4, 30, DateTimeKind.Local).AddTicks(9775));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 8, 7, 4, 30, DateTimeKind.Local).AddTicks(9777));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FoundationDate",
                table: "Developers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Developers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FoundationDate", "Location" },
                values: new object[] { new DateTime(1889, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyoto, Japan" });

            migrationBuilder.UpdateData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FoundationDate", "Location" },
                values: new object[] { new DateTime(2009, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stockholm, Sweden" });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 7, 21, 25, 582, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 7, 21, 25, 582, DateTimeKind.Local).AddTicks(3551));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 7, 21, 25, 582, DateTimeKind.Local).AddTicks(3554));
        }
    }
}

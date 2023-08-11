using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tadas_SOA_Repeat_CA.Migrations
{
    /// <inheritdoc />
    public partial class revertlastmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 9, 21, 10, 681, DateTimeKind.Local).AddTicks(711));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 9, 21, 10, 681, DateTimeKind.Local).AddTicks(759));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordCreationDate",
                value: new DateTime(2023, 8, 11, 9, 21, 10, 681, DateTimeKind.Local).AddTicks(761));
        }
    }
}

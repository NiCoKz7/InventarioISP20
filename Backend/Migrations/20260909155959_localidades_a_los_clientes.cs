using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class localidades_a_los_clientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 9, 12, 59, 58, 993, DateTimeKind.Unspecified).AddTicks(7738), new TimeSpan(0, -3, 0, 0, 0)), 1 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 9, 12, 59, 58, 993, DateTimeKind.Unspecified).AddTicks(7751), new TimeSpan(0, -3, 0, 0, 0)), 2 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 9, 12, 59, 58, 993, DateTimeKind.Unspecified).AddTicks(7753), new TimeSpan(0, -3, 0, 0, 0)), 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 1, 18, 43, 32, 736, DateTimeKind.Unspecified).AddTicks(4986), new TimeSpan(0, -3, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 1, 18, 43, 32, 736, DateTimeKind.Unspecified).AddTicks(5005), new TimeSpan(0, -3, 0, 0, 0)), 0 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_at", "LocalidadId" },
                values: new object[] { new DateTimeOffset(new DateTime(2026, 9, 1, 18, 43, 32, 736, DateTimeKind.Unspecified).AddTicks(5009), new TimeSpan(0, -3, 0, 0, 0)), 0 });
        }
    }
}

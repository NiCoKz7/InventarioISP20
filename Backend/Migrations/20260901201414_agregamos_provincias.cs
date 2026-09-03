using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class agregamos_provincias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProvinciaId",
                table: "Localidades",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 1, 17, 14, 13, 954, DateTimeKind.Unspecified).AddTicks(1257), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 1, 17, 14, 13, 954, DateTimeKind.Unspecified).AddTicks(1273), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 9, 1, 17, 14, 13, 954, DateTimeKind.Unspecified).AddTicks(1275), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProvinciaId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 2,
                column: "ProvinciaId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 3,
                column: "ProvinciaId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "ProvinciaId" },
                values: new object[] { "San Justo", 3 });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Buenos Aires" },
                    { 2, false, "Córdoba" },
                    { 3, false, "Santa Fe" },
                    { 4, false, "Mendoza" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_Provincias_ProvinciaId",
                table: "Localidades",
                column: "ProvinciaId",
                principalTable: "Provincias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_Provincias_ProvinciaId",
                table: "Localidades");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_ProvinciaId",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "ProvinciaId",
                table: "Localidades");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 8, 26, 18, 37, 52, 81, DateTimeKind.Unspecified).AddTicks(8329), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 8, 26, 18, 37, 52, 81, DateTimeKind.Unspecified).AddTicks(8349), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_at",
                value: new DateTimeOffset(new DateTime(2026, 8, 26, 18, 37, 52, 81, DateTimeKind.Unspecified).AddTicks(8352), new TimeSpan(0, -3, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Localidades",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Mendoza");
        }
    }
}

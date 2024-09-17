using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalksAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2a58c91b-6e76-4b82-8103-3fd3fbfaee1f"), "Medium" },
                    { new Guid("4f218539-284b-40b4-9856-1c0a08163b4b"), "Hard" },
                    { new Guid("96f833d2-4212-49b7-a0e6-0940c407c760"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0d79d6d9-f76a-4350-bf93-4a6f3b388831"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("1989b615-dbdc-4f47-b1eb-e379da23a3b7"), "NTL", "Northland", null },
                    { new Guid("241286d4-6d20-4949-bf09-6b7635441a85"), "BOP", "Bay Of Plenty", null },
                    { new Guid("9429d309-dc40-4569-a49e-91740a1e00df"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("a74ad913-b5b0-4225-8c37-1f1ffc684213"), "STL", "Southland", null },
                    { new Guid("c5b31584-3ff8-442e-b3e4-6fd72f189b73"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("2a58c91b-6e76-4b82-8103-3fd3fbfaee1f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4f218539-284b-40b4-9856-1c0a08163b4b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("96f833d2-4212-49b7-a0e6-0940c407c760"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0d79d6d9-f76a-4350-bf93-4a6f3b388831"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1989b615-dbdc-4f47-b1eb-e379da23a3b7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("241286d4-6d20-4949-bf09-6b7635441a85"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9429d309-dc40-4569-a49e-91740a1e00df"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a74ad913-b5b0-4225-8c37-1f1ffc684213"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c5b31584-3ff8-442e-b3e4-6fd72f189b73"));
        }
    }
}

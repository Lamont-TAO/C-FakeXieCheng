using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.NET3.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Fees", "Fetures", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("2ff238b5-5e8d-4761-ba3b-989216ffbe08"), new DateTime(2023, 3, 16, 9, 36, 59, 981, DateTimeKind.Utc).AddTicks(1101), null, "shuoming", null, null, null, null, 0m, "ceshititle", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "ID",
                keyValue: new Guid("2ff238b5-5e8d-4761-ba3b-989216ffbe08"));
        }
    }
}

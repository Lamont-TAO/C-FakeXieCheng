using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FakeXieCheng.NET3.Migrations
{
    public partial class DataSeeding2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "ID",
                keyValue: new Guid("2ff238b5-5e8d-4761-ba3b-989216ffbe08"));

            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Fees", "Fetures", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("fb6d4f10-79ed-4aff-a915-4ce29dc9c7e1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "�����Ŀ�ǰ���", 0.90000000000000002, "null", "null", null, 1299m, "����", null });

            migrationBuilder.InsertData(
                table: "TouristRoutePictures",
                columns: new[] { "Id", "TouristRouteId", "Url" },
                values: new object[] { 1, new Guid("fb6d4f10-79ed-4aff-a915-4ce29dc9c7e1"), "../../assets/images/xxx.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TouristRoutePictures",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TouristRoutes",
                keyColumn: "ID",
                keyValue: new Guid("fb6d4f10-79ed-4aff-a915-4ce29dc9c7e1"));

            migrationBuilder.InsertData(
                table: "TouristRoutes",
                columns: new[] { "ID", "CreateTime", "DepartureTime", "Description", "DiscountPresent", "Fees", "Fetures", "Notes", "OriginalPrice", "Title", "UpdateTime" },
                values: new object[] { new Guid("2ff238b5-5e8d-4761-ba3b-989216ffbe08"), new DateTime(2023, 3, 16, 9, 36, 59, 981, DateTimeKind.Utc).AddTicks(1101), null, "shuoming", null, null, null, null, 0m, "ceshititle", null });
        }
    }
}

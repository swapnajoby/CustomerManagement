using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagement.Migrations
{
    public partial class SeedDataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "BusinessName", "CreatedDate", "DateofBirth", "FirstName", "LastName" },
                values: new object[] { 1, "OnlineService", new DateTime(2021, 8, 14, 23, 48, 21, 769, DateTimeKind.Local).AddTicks(4771), new DateTime(1960, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Mathew" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "BusinessName", "CreatedDate", "DateofBirth", "FirstName", "LastName" },
                values: new object[] { 2, "Hotel", new DateTime(2021, 8, 14, 23, 48, 21, 770, DateTimeKind.Local).AddTicks(3796), new DateTime(2000, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", "Williams" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);
        }
    }
}

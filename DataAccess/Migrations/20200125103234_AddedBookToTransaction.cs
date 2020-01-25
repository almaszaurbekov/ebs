using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedBookToTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("60e51fc5-dc9e-460a-8a08-bbe7376a22bb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("66deef9d-2049-4697-8e3b-2a5aff32b38a"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("57f4d053-4997-48e6-bf2b-304fd60b91ee"), "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 858, DateTimeKind.Utc).AddTicks(6222), "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 858, DateTimeKind.Utc).AddTicks(6242), false, "admin", "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 858, DateTimeKind.Utc).AddTicks(6241) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("02883dee-81b0-4576-82a6-c78a2eae9599"), "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 858, DateTimeKind.Utc).AddTicks(8398), "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 858, DateTimeKind.Utc).AddTicks(8409), false, "user", "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 858, DateTimeKind.Utc).AddTicks(8408) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 859, DateTimeKind.Utc).AddTicks(571), "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 859, DateTimeKind.Utc).AddTicks(579), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("57f4d053-4997-48e6-bf2b-304fd60b91ee"), "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 859, DateTimeKind.Utc).AddTicks(578) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 886, DateTimeKind.Utc).AddTicks(464), "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 886, DateTimeKind.Utc).AddTicks(580), "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("02883dee-81b0-4576-82a6-c78a2eae9599"), "ebs", new DateTime(2020, 1, 25, 10, 32, 31, 886, DateTimeKind.Utc).AddTicks(576) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("02883dee-81b0-4576-82a6-c78a2eae9599"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("57f4d053-4997-48e6-bf2b-304fd60b91ee"));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("60e51fc5-dc9e-460a-8a08-bbe7376a22bb"), "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 481, DateTimeKind.Utc).AddTicks(9273), "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 481, DateTimeKind.Utc).AddTicks(9295), false, "admin", "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 481, DateTimeKind.Utc).AddTicks(9294) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("66deef9d-2049-4697-8e3b-2a5aff32b38a"), "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 482, DateTimeKind.Utc).AddTicks(2142), "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 482, DateTimeKind.Utc).AddTicks(2151), false, "user", "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 482, DateTimeKind.Utc).AddTicks(2150) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 482, DateTimeKind.Utc).AddTicks(5825), "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 482, DateTimeKind.Utc).AddTicks(5835), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("60e51fc5-dc9e-460a-8a08-bbe7376a22bb"), "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 482, DateTimeKind.Utc).AddTicks(5834) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 489, DateTimeKind.Utc).AddTicks(3944), "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 489, DateTimeKind.Utc).AddTicks(3967), "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("66deef9d-2049-4697-8e3b-2a5aff32b38a"), "ebs", new DateTime(2020, 1, 24, 7, 5, 57, 489, DateTimeKind.Utc).AddTicks(3966) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedOwnerPropertiesToTransaction : Migration
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
                keyValue: new Guid("7905b82d-8adc-4e96-b7d2-7328ea95472c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e631fa07-e5cf-415b-97be-bd812325c1e2"));

            migrationBuilder.AddColumn<bool>(
                name: "OwnerAgreed",
                table: "BookTransactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OwnerHasSeen",
                table: "BookTransactions",
                nullable: false,
                defaultValue: false);

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
                keyValue: new Guid("60e51fc5-dc9e-460a-8a08-bbe7376a22bb"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("66deef9d-2049-4697-8e3b-2a5aff32b38a"));

            migrationBuilder.DropColumn(
                name: "OwnerAgreed",
                table: "BookTransactions");

            migrationBuilder.DropColumn(
                name: "OwnerHasSeen",
                table: "BookTransactions");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("e631fa07-e5cf-415b-97be-bd812325c1e2"), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 111, DateTimeKind.Utc).AddTicks(8170), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 111, DateTimeKind.Utc).AddTicks(8192), false, "admin", "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 111, DateTimeKind.Utc).AddTicks(8191) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("7905b82d-8adc-4e96-b7d2-7328ea95472c"), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(220), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(225), false, "user", "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(224) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(2441), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(2445), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("e631fa07-e5cf-415b-97be-bd812325c1e2"), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(2445) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 117, DateTimeKind.Utc).AddTicks(7686), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 117, DateTimeKind.Utc).AddTicks(7708), "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("7905b82d-8adc-4e96-b7d2-7328ea95472c"), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 117, DateTimeKind.Utc).AddTicks(7706) });
        }
    }
}

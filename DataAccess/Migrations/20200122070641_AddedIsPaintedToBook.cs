using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedIsPaintedToBook : Migration
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
                keyValue: new Guid("1a3bd16f-41de-46e5-980e-6f61cda8b276"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3aa38b21-ba5f-4855-ac45-8aad903d0fc3"));

            migrationBuilder.AddColumn<bool>(
                name: "InGoodCondition",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPainted",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("1e0be03c-e4aa-48a1-bca1-b96bcbee65a5"), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(760), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(782), false, "admin", "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(781) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("a5335879-3c7a-4e61-956f-a752805f6037"), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(2711), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(2716), false, "user", "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(5004), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(5011), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("1e0be03c-e4aa-48a1-bca1-b96bcbee65a5"), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 629, DateTimeKind.Utc).AddTicks(1784), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 629, DateTimeKind.Utc).AddTicks(1804), "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("a5335879-3c7a-4e61-956f-a752805f6037"), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 629, DateTimeKind.Utc).AddTicks(1803) });
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
                keyValue: new Guid("1e0be03c-e4aa-48a1-bca1-b96bcbee65a5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a5335879-3c7a-4e61-956f-a752805f6037"));

            migrationBuilder.DropColumn(
                name: "InGoodCondition",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsPainted",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("1a3bd16f-41de-46e5-980e-6f61cda8b276"), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(5257), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(5275), false, "admin", "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(5274) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("3aa38b21-ba5f-4855-ac45-8aad903d0fc3"), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(7236), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(7242), false, "user", "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(9309), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(9313), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("1a3bd16f-41de-46e5-980e-6f61cda8b276"), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(9312) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 821, DateTimeKind.Utc).AddTicks(6468), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 821, DateTimeKind.Utc).AddTicks(6489), "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("3aa38b21-ba5f-4855-ac45-8aad903d0fc3"), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 821, DateTimeKind.Utc).AddTicks(6488) });
        }
    }
}

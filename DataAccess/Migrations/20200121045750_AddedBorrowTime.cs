using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedBorrowTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("042d3545-2039-4bf1-8b97-53685d608dc4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2f1c5233-2c64-4cab-9186-5e622b4fcc6b"));

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowEndDate",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowStartDate",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("fe68a1c8-4052-4575-93ea-3c4e02395f8b"), "ebs", new DateTime(2020, 1, 21, 4, 57, 43, 447, DateTimeKind.Utc).AddTicks(4803), "ebs", new DateTime(2020, 1, 21, 4, 57, 43, 447, DateTimeKind.Utc).AddTicks(4829), false, "admin", "ebs", new DateTime(2020, 1, 21, 4, 57, 43, 447, DateTimeKind.Utc).AddTicks(4827) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("d182a098-c0c4-4270-afd2-7fb42061788e"), "ebs", new DateTime(2020, 1, 21, 4, 57, 43, 448, DateTimeKind.Utc).AddTicks(1130), "ebs", new DateTime(2020, 1, 21, 4, 57, 43, 448, DateTimeKind.Utc).AddTicks(1154), false, "user", "ebs", new DateTime(2020, 1, 21, 4, 57, 43, 448, DateTimeKind.Utc).AddTicks(1152) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 21, 4, 57, 43, 448, DateTimeKind.Utc).AddTicks(6914), "ebs", new DateTime(2020, 1, 21, 4, 57, 43, 448, DateTimeKind.Utc).AddTicks(6945), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("fe68a1c8-4052-4575-93ea-3c4e02395f8b"), "ebs", new DateTime(2020, 1, 21, 4, 57, 43, 448, DateTimeKind.Utc).AddTicks(6942) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d182a098-c0c4-4270-afd2-7fb42061788e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("fe68a1c8-4052-4575-93ea-3c4e02395f8b"));

            migrationBuilder.DropColumn(
                name: "BorrowEndDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BorrowStartDate",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("2f1c5233-2c64-4cab-9186-5e622b4fcc6b"), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(3871), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(3917), false, "admin", "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(3915) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("042d3545-2039-4bf1-8b97-53685d608dc4"), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(6683), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(6695), false, "user", "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(6694) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(9799), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(9808), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("2f1c5233-2c64-4cab-9186-5e622b4fcc6b"), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(9807) });
        }
    }
}

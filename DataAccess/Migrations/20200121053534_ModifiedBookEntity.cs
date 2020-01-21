using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ModifiedBookEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsBorrowed",
                table: "Books",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("58c1a956-025e-470b-a21d-7aba51f35714"), "ebs", new DateTime(2020, 1, 21, 5, 35, 30, 309, DateTimeKind.Utc).AddTicks(6135), "ebs", new DateTime(2020, 1, 21, 5, 35, 30, 309, DateTimeKind.Utc).AddTicks(6154), false, "admin", "ebs", new DateTime(2020, 1, 21, 5, 35, 30, 309, DateTimeKind.Utc).AddTicks(6153) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("c71fd177-bb25-4b9c-8cdb-aa73fdddbd51"), "ebs", new DateTime(2020, 1, 21, 5, 35, 30, 309, DateTimeKind.Utc).AddTicks(8148), "ebs", new DateTime(2020, 1, 21, 5, 35, 30, 309, DateTimeKind.Utc).AddTicks(8155), false, "user", "ebs", new DateTime(2020, 1, 21, 5, 35, 30, 309, DateTimeKind.Utc).AddTicks(8154) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 21, 5, 35, 30, 310, DateTimeKind.Utc).AddTicks(872), "ebs", new DateTime(2020, 1, 21, 5, 35, 30, 310, DateTimeKind.Utc).AddTicks(878), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("58c1a956-025e-470b-a21d-7aba51f35714"), "ebs", new DateTime(2020, 1, 21, 5, 35, 30, 310, DateTimeKind.Utc).AddTicks(877) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c71fd177-bb25-4b9c-8cdb-aa73fdddbd51"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("58c1a956-025e-470b-a21d-7aba51f35714"));

            migrationBuilder.DropColumn(
                name: "IsBorrowed",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowEndDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowStartDate",
                table: "Books",
                type: "datetime2",
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
    }
}

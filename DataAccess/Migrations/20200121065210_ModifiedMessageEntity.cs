using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ModifiedMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "HasRead",
                table: "Messages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserReceiverEmail",
                table: "Messages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserSenderEmail",
                table: "Messages",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("11ea3380-fac4-4fb6-91f8-301ffdd304d9"), "ebs", new DateTime(2020, 1, 21, 6, 52, 0, 27, DateTimeKind.Utc).AddTicks(2569), "ebs", new DateTime(2020, 1, 21, 6, 52, 0, 27, DateTimeKind.Utc).AddTicks(2591), false, "admin", "ebs", new DateTime(2020, 1, 21, 6, 52, 0, 27, DateTimeKind.Utc).AddTicks(2590) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("13bd16d4-8541-4360-890a-c13764ae7821"), "ebs", new DateTime(2020, 1, 21, 6, 52, 0, 27, DateTimeKind.Utc).AddTicks(4861), "ebs", new DateTime(2020, 1, 21, 6, 52, 0, 27, DateTimeKind.Utc).AddTicks(4871), false, "user", "ebs", new DateTime(2020, 1, 21, 6, 52, 0, 27, DateTimeKind.Utc).AddTicks(4869) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 21, 6, 52, 0, 27, DateTimeKind.Utc).AddTicks(8079), "ebs", new DateTime(2020, 1, 21, 6, 52, 0, 27, DateTimeKind.Utc).AddTicks(8089), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("11ea3380-fac4-4fb6-91f8-301ffdd304d9"), "ebs", new DateTime(2020, 1, 21, 6, 52, 0, 27, DateTimeKind.Utc).AddTicks(8087) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("13bd16d4-8541-4360-890a-c13764ae7821"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("11ea3380-fac4-4fb6-91f8-301ffdd304d9"));

            migrationBuilder.DropColumn(
                name: "HasRead",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserReceiverEmail",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserSenderEmail",
                table: "Messages");

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
    }
}

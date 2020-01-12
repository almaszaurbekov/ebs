using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("da9b144b-f631-47cf-a30a-23fe0f0a6672"), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(2621), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(2642), false, "admin", "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(2641) });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("82fad6cd-3eec-45cc-9b59-e8020c2433f9"), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(5229), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(5237), false, "user", "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(5235) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(7726), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(7733), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("da9b144b-f631-47cf-a30a-23fe0f0a6672"), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(7732) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");
        }
    }
}

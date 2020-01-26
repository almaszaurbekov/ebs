using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedSecondInterlocutorToDialog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DialogControls_Users_InterlocutorId",
                table: "DialogControls");

            migrationBuilder.DropIndex(
                name: "IX_DialogControls_InterlocutorId",
                table: "DialogControls");

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
                keyValue: new Guid("09c4f15d-5787-4b84-9c3d-580eaffb70d2"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("40281e27-1122-45f3-852d-df7c8cd94825"));

            migrationBuilder.DropColumn(
                name: "InterlocutorId",
                table: "DialogControls");

            migrationBuilder.AddColumn<string>(
                name: "FirstInterlocutorEmail",
                table: "DialogControls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirstInterlocutorId",
                table: "DialogControls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SecondInterlocutorEmail",
                table: "DialogControls",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondInterlocutorId",
                table: "DialogControls",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DialogControls",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("ab081903-d5f5-4216-9680-5209b40ef9f6"), "ebs", new DateTime(2020, 1, 26, 9, 28, 27, 534, DateTimeKind.Utc).AddTicks(1644), null, null, false, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("a3c2ded9-6757-485a-a108-9333601f91e0"), "ebs", new DateTime(2020, 1, 26, 9, 28, 27, 534, DateTimeKind.Utc).AddTicks(4398), null, null, false, "user", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 26, 9, 28, 27, 534, DateTimeKind.Utc).AddTicks(7435), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("ab081903-d5f5-4216-9680-5209b40ef9f6"), null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 26, 9, 28, 27, 539, DateTimeKind.Utc).AddTicks(4434), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("a3c2ded9-6757-485a-a108-9333601f91e0"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_DialogControls_UserId",
                table: "DialogControls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DialogControls_Users_UserId",
                table: "DialogControls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DialogControls_Users_UserId",
                table: "DialogControls");

            migrationBuilder.DropIndex(
                name: "IX_DialogControls_UserId",
                table: "DialogControls");

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
                keyValue: new Guid("a3c2ded9-6757-485a-a108-9333601f91e0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ab081903-d5f5-4216-9680-5209b40ef9f6"));

            migrationBuilder.DropColumn(
                name: "FirstInterlocutorEmail",
                table: "DialogControls");

            migrationBuilder.DropColumn(
                name: "FirstInterlocutorId",
                table: "DialogControls");

            migrationBuilder.DropColumn(
                name: "SecondInterlocutorEmail",
                table: "DialogControls");

            migrationBuilder.DropColumn(
                name: "SecondInterlocutorId",
                table: "DialogControls");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DialogControls");

            migrationBuilder.AddColumn<int>(
                name: "InterlocutorId",
                table: "DialogControls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("09c4f15d-5787-4b84-9c3d-580eaffb70d2"), "ebs", new DateTime(2020, 1, 26, 8, 56, 55, 155, DateTimeKind.Utc).AddTicks(2866), null, null, false, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("40281e27-1122-45f3-852d-df7c8cd94825"), "ebs", new DateTime(2020, 1, 26, 8, 56, 55, 155, DateTimeKind.Utc).AddTicks(6173), null, null, false, "user", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 26, 8, 56, 55, 156, DateTimeKind.Utc).AddTicks(1019), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("09c4f15d-5787-4b84-9c3d-580eaffb70d2"), null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 26, 8, 56, 55, 184, DateTimeKind.Utc).AddTicks(8691), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("40281e27-1122-45f3-852d-df7c8cd94825"), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_DialogControls_InterlocutorId",
                table: "DialogControls",
                column: "InterlocutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DialogControls_Users_InterlocutorId",
                table: "DialogControls",
                column: "InterlocutorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

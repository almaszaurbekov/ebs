using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ModifiedTransactionDataType : Migration
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
                keyValue: new Guid("a3c2ded9-6757-485a-a108-9333601f91e0"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ab081903-d5f5-4216-9680-5209b40ef9f6"));

            migrationBuilder.AlterColumn<int>(
                name: "OwnerAgreed",
                table: "BookTransactions",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IsSuccess",
                table: "BookTransactions",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("ddd0e4bc-bb9f-4825-ba2e-c5912aa29d13"), "ebs", new DateTime(2020, 1, 26, 9, 32, 28, 397, DateTimeKind.Utc).AddTicks(9749), null, null, false, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("0f996da0-1a2f-4572-a758-3134cae8276c"), "ebs", new DateTime(2020, 1, 26, 9, 32, 28, 398, DateTimeKind.Utc).AddTicks(1693), null, null, false, "user", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 26, 9, 32, 28, 398, DateTimeKind.Utc).AddTicks(3715), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("ddd0e4bc-bb9f-4825-ba2e-c5912aa29d13"), null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 26, 9, 32, 28, 415, DateTimeKind.Utc).AddTicks(5837), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("0f996da0-1a2f-4572-a758-3134cae8276c"), null, null });
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
                keyValue: new Guid("0f996da0-1a2f-4572-a758-3134cae8276c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("ddd0e4bc-bb9f-4825-ba2e-c5912aa29d13"));

            migrationBuilder.AlterColumn<bool>(
                name: "OwnerAgreed",
                table: "BookTransactions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<bool>(
                name: "IsSuccess",
                table: "BookTransactions",
                type: "bit",
                nullable: true,
                oldClrType: typeof(int));

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
        }
    }
}

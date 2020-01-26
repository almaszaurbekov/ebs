using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedNullableFields : Migration
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
                keyValue: new Guid("02883dee-81b0-4576-82a6-c78a2eae9599"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("57f4d053-4997-48e6-bf2b-304fd60b91ee"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Users",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Roles",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Messages",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DialogControls",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "DialogControls",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BookTransactions",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "OwnerAgreed",
                table: "BookTransactions",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsSuccess",
                table: "BookTransactions",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "BookTransactions",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Books",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Books",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("f434648b-7ae8-484b-aa91-4ab8589f68a7"), "ebs", new DateTime(2020, 1, 26, 6, 51, 40, 842, DateTimeKind.Utc).AddTicks(6187), null, null, false, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("a38f7ddb-f7a5-4652-b1cd-b487520ff0fd"), "ebs", new DateTime(2020, 1, 26, 6, 51, 40, 842, DateTimeKind.Utc).AddTicks(9005), null, null, false, "user", null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 26, 6, 51, 40, 843, DateTimeKind.Utc).AddTicks(2118), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("f434648b-7ae8-484b-aa91-4ab8589f68a7"), null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 26, 6, 51, 40, 854, DateTimeKind.Utc).AddTicks(9078), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("a38f7ddb-f7a5-4652-b1cd-b487520ff0fd"), null, null });
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
                keyValue: new Guid("a38f7ddb-f7a5-4652-b1cd-b487520ff0fd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f434648b-7ae8-484b-aa91-4ab8589f68a7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Roles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "DialogControls",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "DialogControls",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "BookTransactions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "OwnerAgreed",
                table: "BookTransactions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSuccess",
                table: "BookTransactions",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "BookTransactions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

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
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedBcBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("648d229f-e9b9-4ff9-b448-33a78cd5072c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("91f94a7b-d96a-42df-b7af-086259d597bb"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BcBooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    Rate = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    PublishYear = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Pages = table.Column<string>(nullable: true),
                    Cover = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Thickness = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BcBooks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("2f1c5233-2c64-4cab-9186-5e622b4fcc6b"), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(3871), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(3917), false, "admin", "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(3915) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("042d3545-2039-4bf1-8b97-53685d608dc4"), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(6683), "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(6695), false, "user", "ebs", new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(6694) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "RoleId", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(9799), new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(9808), new Guid("2f1c5233-2c64-4cab-9186-5e622b4fcc6b"), new DateTime(2020, 1, 14, 15, 30, 13, 867, DateTimeKind.Utc).AddTicks(9807) });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "BcBooks");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("042d3545-2039-4bf1-8b97-53685d608dc4"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2f1c5233-2c64-4cab-9186-5e622b4fcc6b"));

            migrationBuilder.AlterColumn<Guid>(
                name: "RoleId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("648d229f-e9b9-4ff9-b448-33a78cd5072c"), "ebs", new DateTime(2020, 1, 13, 3, 26, 55, 855, DateTimeKind.Utc).AddTicks(65), "ebs", new DateTime(2020, 1, 13, 3, 26, 55, 855, DateTimeKind.Utc).AddTicks(81), false, "admin", "ebs", new DateTime(2020, 1, 13, 3, 26, 55, 855, DateTimeKind.Utc).AddTicks(80) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("91f94a7b-d96a-42df-b7af-086259d597bb"), "ebs", new DateTime(2020, 1, 13, 3, 26, 55, 855, DateTimeKind.Utc).AddTicks(1325), "ebs", new DateTime(2020, 1, 13, 3, 26, 55, 855, DateTimeKind.Utc).AddTicks(1329), false, "user", "ebs", new DateTime(2020, 1, 13, 3, 26, 55, 855, DateTimeKind.Utc).AddTicks(1328) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "RoleId", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 1, 13, 3, 26, 55, 855, DateTimeKind.Utc).AddTicks(2924), new DateTime(2020, 1, 13, 3, 26, 55, 855, DateTimeKind.Utc).AddTicks(2928), new Guid("648d229f-e9b9-4ff9-b448-33a78cd5072c"), new DateTime(2020, 1, 13, 3, 26, 55, 855, DateTimeKind.Utc).AddTicks(2927) });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

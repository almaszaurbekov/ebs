using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("82fad6cd-3eec-45cc-9b59-e8020c2433f9"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("da9b144b-f631-47cf-a30a-23fe0f0a6672"));

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    UserSenderId = table.Column<int>(nullable: false),
                    UserReceiverId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("648d229f-e9b9-4ff9-b448-33a78cd5072c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("91f94a7b-d96a-42df-b7af-086259d597bb"));

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("da9b144b-f631-47cf-a30a-23fe0f0a6672"), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(2621), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(2642), false, "admin", "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(2641) });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("82fad6cd-3eec-45cc-9b59-e8020c2433f9"), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(5229), "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(5237), false, "user", "ebs", new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(5235) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "DeletedDate", "RoleId", "UpdatedDate" },
                values: new object[] { new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(7726), new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(7733), new Guid("da9b144b-f631-47cf-a30a-23fe0f0a6672"), new DateTime(2020, 1, 10, 8, 2, 54, 708, DateTimeKind.Utc).AddTicks(7732) });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Role_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

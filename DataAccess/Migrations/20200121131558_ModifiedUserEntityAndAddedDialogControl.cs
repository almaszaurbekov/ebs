using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ModifiedUserEntityAndAddedDialogControl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

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
                name: "UserId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "DialogControlId",
                table: "Messages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DialogControl",
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
                    LastMessage = table.Column<string>(nullable: true),
                    LastMessageDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DialogControl_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("9de4a589-07dc-4fab-9aab-8062bd35772f"), "ebs", new DateTime(2020, 1, 21, 13, 15, 55, 581, DateTimeKind.Utc).AddTicks(3503), "ebs", new DateTime(2020, 1, 21, 13, 15, 55, 581, DateTimeKind.Utc).AddTicks(3523), false, "admin", "ebs", new DateTime(2020, 1, 21, 13, 15, 55, 581, DateTimeKind.Utc).AddTicks(3521) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("1dfde219-9b00-4d13-86e2-a4e71d654686"), "ebs", new DateTime(2020, 1, 21, 13, 15, 55, 581, DateTimeKind.Utc).AddTicks(5535), "ebs", new DateTime(2020, 1, 21, 13, 15, 55, 581, DateTimeKind.Utc).AddTicks(5542), false, "user", "ebs", new DateTime(2020, 1, 21, 13, 15, 55, 581, DateTimeKind.Utc).AddTicks(5541) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 21, 13, 15, 55, 581, DateTimeKind.Utc).AddTicks(7683), "ebs", new DateTime(2020, 1, 21, 13, 15, 55, 581, DateTimeKind.Utc).AddTicks(7690), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("9de4a589-07dc-4fab-9aab-8062bd35772f"), "ebs", new DateTime(2020, 1, 21, 13, 15, 55, 581, DateTimeKind.Utc).AddTicks(7688) });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DialogControlId",
                table: "Messages",
                column: "DialogControlId");

            migrationBuilder.CreateIndex(
                name: "IX_DialogControl_UserId",
                table: "DialogControl",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_DialogControl_DialogControlId",
                table: "Messages",
                column: "DialogControlId",
                principalTable: "DialogControl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_DialogControl_DialogControlId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "DialogControl");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DialogControlId",
                table: "Messages");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1dfde219-9b00-4d13-86e2-a4e71d654686"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9de4a589-07dc-4fab-9aab-8062bd35772f"));

            migrationBuilder.DropColumn(
                name: "DialogControlId",
                table: "Messages");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Messages",
                type: "int",
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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

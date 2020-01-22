using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DialogControl_Users_UserId",
                table: "DialogControl");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_DialogControl_DialogControlId",
                table: "Messages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DialogControl",
                table: "DialogControl");

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

            migrationBuilder.RenameTable(
                name: "DialogControl",
                newName: "DialogControls");

            migrationBuilder.RenameIndex(
                name: "IX_DialogControl_UserId",
                table: "DialogControls",
                newName: "IX_DialogControls_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DialogControls",
                table: "DialogControls",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BorrowStartDate = table.Column<DateTime>(nullable: false),
                    BorrowEndDate = table.Column<DateTime>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    BorrowerId = table.Column<int>(nullable: false),
                    IsSuccess = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("1a3bd16f-41de-46e5-980e-6f61cda8b276"), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(5257), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(5275), false, "admin", "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(5274) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("3aa38b21-ba5f-4855-ac45-8aad903d0fc3"), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(7236), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(7242), false, "user", "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(7240) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(9309), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(9313), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("1a3bd16f-41de-46e5-980e-6f61cda8b276"), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 816, DateTimeKind.Utc).AddTicks(9312) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 821, DateTimeKind.Utc).AddTicks(6468), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 821, DateTimeKind.Utc).AddTicks(6489), "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("3aa38b21-ba5f-4855-ac45-8aad903d0fc3"), "ebs", new DateTime(2020, 1, 22, 6, 55, 53, 821, DateTimeKind.Utc).AddTicks(6488) });

            migrationBuilder.AddForeignKey(
                name: "FK_DialogControls_Users_UserId",
                table: "DialogControls",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_DialogControls_DialogControlId",
                table: "Messages",
                column: "DialogControlId",
                principalTable: "DialogControls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DialogControls_Users_UserId",
                table: "DialogControls");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_DialogControls_DialogControlId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DialogControls",
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
                keyValue: new Guid("1a3bd16f-41de-46e5-980e-6f61cda8b276"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3aa38b21-ba5f-4855-ac45-8aad903d0fc3"));

            migrationBuilder.RenameTable(
                name: "DialogControls",
                newName: "DialogControl");

            migrationBuilder.RenameIndex(
                name: "IX_DialogControls_UserId",
                table: "DialogControl",
                newName: "IX_DialogControl_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DialogControl",
                table: "DialogControl",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_DialogControl_Users_UserId",
                table: "DialogControl",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_DialogControl_DialogControlId",
                table: "Messages",
                column: "DialogControlId",
                principalTable: "DialogControl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

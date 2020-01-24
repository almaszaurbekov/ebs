using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ProbablyTransactionWasModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

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
                keyValue: new Guid("1e0be03c-e4aa-48a1-bca1-b96bcbee65a5"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("a5335879-3c7a-4e61-956f-a752805f6037"));

            migrationBuilder.CreateTable(
                name: "BookTransactions",
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
                    BorrowStartDate = table.Column<DateTime>(nullable: false),
                    BorrowEndDate = table.Column<DateTime>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    BorrowerId = table.Column<int>(nullable: false),
                    IsSuccess = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTransactions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("e631fa07-e5cf-415b-97be-bd812325c1e2"), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 111, DateTimeKind.Utc).AddTicks(8170), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 111, DateTimeKind.Utc).AddTicks(8192), false, "admin", "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 111, DateTimeKind.Utc).AddTicks(8191) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("7905b82d-8adc-4e96-b7d2-7328ea95472c"), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(220), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(225), false, "user", "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(224) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(2441), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(2445), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("e631fa07-e5cf-415b-97be-bd812325c1e2"), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 112, DateTimeKind.Utc).AddTicks(2445) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 117, DateTimeKind.Utc).AddTicks(7686), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 117, DateTimeKind.Utc).AddTicks(7708), "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("7905b82d-8adc-4e96-b7d2-7328ea95472c"), "ebs", new DateTime(2020, 1, 24, 6, 33, 17, 117, DateTimeKind.Utc).AddTicks(7706) });

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_BookId",
                table: "BookTransactions",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTransactions");

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
                keyValue: new Guid("7905b82d-8adc-4e96-b7d2-7328ea95472c"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e631fa07-e5cf-415b-97be-bd812325c1e2"));

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BorrowEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BorrowStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BorrowerId = table.Column<int>(type: "int", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("1e0be03c-e4aa-48a1-bca1-b96bcbee65a5"), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(760), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(782), false, "admin", "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(781) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("a5335879-3c7a-4e61-956f-a752805f6037"), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(2711), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(2716), false, "user", "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(2715) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(5004), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(5011), "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("1e0be03c-e4aa-48a1-bca1-b96bcbee65a5"), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 624, DateTimeKind.Utc).AddTicks(5010) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 629, DateTimeKind.Utc).AddTicks(1784), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 629, DateTimeKind.Utc).AddTicks(1804), "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("a5335879-3c7a-4e61-956f-a752805f6037"), "ebs", new DateTime(2020, 1, 22, 7, 6, 39, 629, DateTimeKind.Utc).AddTicks(1803) });
        }
    }
}

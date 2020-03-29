using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ImageSource = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Rate = table.Column<double>(nullable: false),
                    ImageSource = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    IsBorrowed = table.Column<bool>(nullable: false),
                    InGoodCondition = table.Column<bool>(nullable: false),
                    IsPainted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DialogControls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    LastMessage = table.Column<string>(nullable: true),
                    LastMessageDate = table.Column<DateTime>(nullable: false),
                    FirstInterlocutorId = table.Column<int>(nullable: false),
                    FirstInterlocutorEmail = table.Column<string>(nullable: true),
                    SecondInterlocutorId = table.Column<int>(nullable: false),
                    SecondInterlocutorEmail = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialogControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DialogControls_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    BorrowStartDate = table.Column<DateTime>(nullable: false),
                    BorrowEndDate = table.Column<DateTime>(nullable: false),
                    BookId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false),
                    BorrowerId = table.Column<int>(nullable: false),
                    IsSuccess = table.Column<int>(nullable: false),
                    OwnerHasSeen = table.Column<bool>(nullable: false),
                    OwnerAgreed = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 256, nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
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
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedBy = table.Column<string>(maxLength: 256, nullable: true),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    UserSenderId = table.Column<int>(nullable: false),
                    UserReceiverId = table.Column<int>(nullable: false),
                    UserSenderEmail = table.Column<string>(nullable: true),
                    UserReceiverEmail = table.Column<string>(nullable: true),
                    HasRead = table.Column<bool>(nullable: false),
                    DialogControlId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_DialogControls_DialogControlId",
                        column: x => x.DialogControlId,
                        principalTable: "DialogControls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DialogControls",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FirstInterlocutorEmail", "FirstInterlocutorId", "IsDeleted", "LastMessage", "LastMessageDate", "SecondInterlocutorEmail", "SecondInterlocutorId", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 815, DateTimeKind.Utc).AddTicks(971), null, null, "foxxychmoxy@gmail.com", 1, false, "Hello! Yes, I know. Thank you!", new DateTime(2020, 3, 28, 18, 41, 33, 815, DateTimeKind.Utc).AddTicks(4348), "almasgaara@mail.ru", 2, null, null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("c0f08afd-19df-4c48-b022-8ad1bbf2e132"), "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 808, DateTimeKind.Utc).AddTicks(3654), null, null, false, "admin", null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { new Guid("67258a53-b254-41af-9d26-5200835986b3"), "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 808, DateTimeKind.Utc).AddTicks(5737), null, null, false, "user", null, null });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DialogControlId", "HasRead", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserReceiverEmail", "UserReceiverId", "UserSenderEmail", "UserSenderId" },
                values: new object[,]
                {
                    { 1, "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 815, DateTimeKind.Utc).AddTicks(5550), null, null, 1, true, false, "Hi! You are beautiful.", null, null, "almasgaara@mail.ru", 2, "foxxychmoxy@gmail.com", 1 },
                    { 2, "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 815, DateTimeKind.Utc).AddTicks(9953), null, null, 1, true, false, "Hello! Yes, I know. Thank you!", null, null, "foxxychmoxy@gmail.com", 1, "almasgaara@mail.ru", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 808, DateTimeKind.Utc).AddTicks(7812), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("c0f08afd-19df-4c48-b022-8ad1bbf2e132"), null, null },
                    { 2, null, "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(614), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("67258a53-b254-41af-9d26-5200835986b3"), null, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "ImageSource", "InGoodCondition", "IsBorrowed", "IsDeleted", "IsPainted", "Rate", "Title", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Жюль Верн", "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(1899), null, null, "Very good book", "https://static.librebook.me/uploads/pics/01/61/852.jpg", true, false, false, false, 3.0, "20 тысяч лье под водой", null, null, 1 },
                    { 2, "Жюль Верн", "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(8110), null, null, "Very good book", "https://www.mann-ivanov-ferber.ru/assets/images/covers/37/21737/1.00x-thumb.png", true, false, false, false, 4.0, "Дети капитана Гранта", null, null, 1 },
                    { 3, "Жюль Верн", "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(8220), null, null, "Very good book", "https://be2.aldebaran.ru/static/bookimages/42/41/09/42410912.bin.dir/42410912.cover.jpg", true, false, false, false, 3.0, "Вокруг света за 80 дней", null, null, 1 },
                    { 4, "Жюль Верн", "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(8224), null, null, "Very good book", "https://j.livelib.ru/boocover/1001542410/o/1833/Zhyul_Vern__Puteshestvie_k_tsentru_Zemli.jpeg", true, false, false, false, 2.0, "Путешествие к центру земли", null, null, 1 },
                    { 5, "Джоан Роулинг", "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(8226), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/86/25/86251214-92ea-44e9-a394-1a9ef1211400.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и философский камень", null, null, 1 },
                    { 6, "Джоан Роулинг", "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(8233), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/37/81/37811194-8ad9-45a1-b394-9960b57b511f.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и кубок огня книга", null, null, 2 },
                    { 7, "Джоан Роулинг", "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(8236), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/db/53/db53dd7e-10da-471a-b33e-2669f5a5abe9.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и орден феникса", null, null, 2 },
                    { 8, "Федор Достоевский", "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(8238), null, null, "Very good book", "https://azbyka.ru/fiction/wp-content/uploads/2013/02/55.jpg", true, false, false, false, 3.0, "Идиот", null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 814, DateTimeKind.Utc).AddTicks(8758), null, null, false, "I think this is amazing book!", null, null, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 2, 6, "ebs", new DateTime(2020, 3, 28, 18, 41, 33, 815, DateTimeKind.Utc).AddTicks(109), null, null, false, "This is awful book...", null, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_BookId",
                table: "BookTransactions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookId",
                table: "Comments",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_DialogControls_UserId",
                table: "DialogControls",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DialogControlId",
                table: "Messages",
                column: "DialogControlId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BcBooks");

            migrationBuilder.DropTable(
                name: "BookTransactions");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "DialogControls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

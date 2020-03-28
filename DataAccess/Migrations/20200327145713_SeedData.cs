using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: 1);

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: 2);

            //migrationBuilder.DeleteData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: new Guid("0ccc5a70-953e-4dbc-93c7-b79e2d273c0a"));

            //migrationBuilder.DeleteData(
            //    table: "Roles",
            //    keyColumn: "Id",
            //    keyValue: new Guid("7848f4a7-c00f-44a6-a4bf-28d72c882c1b"));

            migrationBuilder.InsertData(
                table: "DialogControls",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FirstInterlocutorEmail", "FirstInterlocutorId", "IsDeleted", "LastMessage", "LastMessageDate", "SecondInterlocutorEmail", "SecondInterlocutorId", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 274, DateTimeKind.Utc).AddTicks(2840), null, null, "foxxychmoxy@gmail.com", 1, false, "Hello! Yes, I know. Thank you!", new DateTime(2020, 3, 27, 14, 57, 1, 274, DateTimeKind.Utc).AddTicks(7939), "almasgaara@mail.ru", 2, null, null, null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,] 
                {
                    { new Guid("da9ec19d-9654-4004-8adb-07d9916a3109"), "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 263, DateTimeKind.Utc).AddTicks(7315), null, null, false, "admin", null, null },
                    { new Guid("c51777ca-e0bf-4b3e-9fe2-14cb19603a10"), "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 264, DateTimeKind.Utc).AddTicks(387), null, null, false, "user", null, null }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DialogControlId", "HasRead", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserReceiverEmail", "UserReceiverId", "UserSenderEmail", "UserSenderId" },
                values: new object[,]
                {
                    { 1, "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 274, DateTimeKind.Utc).AddTicks(9338), null, null, 1, true, false, "Hi! You are beautiful.", null, null, "almasgaara@mail.ru", 2, "foxxychmoxy@gmail.com", 1 },
                    { 2, "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 275, DateTimeKind.Utc).AddTicks(3666), null, null, 1, true, false, "Hello! Yes, I know. Thank you!", null, null, "foxxychmoxy@gmail.com", 1, "almasgaara@mail.ru", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 264, DateTimeKind.Utc).AddTicks(3834), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("da9ec19d-9654-4004-8adb-07d9916a3109"), null, null },
                    { 2, null, "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 272, DateTimeKind.Utc).AddTicks(6601), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("c51777ca-e0bf-4b3e-9fe2-14cb19603a10"), null, null }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "ImageSource", "InGoodCondition", "IsBorrowed", "IsDeleted", "IsPainted", "Rate", "Title", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Жюль Верн", "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 272, DateTimeKind.Utc).AddTicks(8407), null, null, "Very good book", "https://static.librebook.me/uploads/pics/01/61/852.jpg", true, false, false, false, 3.0, "20 тысяч лье под водой", null, null, 1 },
                    { 2, "Жюль Верн", "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 273, DateTimeKind.Utc).AddTicks(8080), null, null, "Very good book", "https://www.mann-ivanov-ferber.ru/assets/images/covers/37/21737/1.00x-thumb.png", true, false, false, false, 4.0, "Дети капитана Гранта", null, null, 1 },
                    { 3, "Жюль Верн", "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 273, DateTimeKind.Utc).AddTicks(8283), null, null, "Very good book", "https://be2.aldebaran.ru/static/bookimages/42/41/09/42410912.bin.dir/42410912.cover.jpg", true, false, false, false, 3.0, "Вокруг света за 80 дней", null, null, 1 },
                    { 4, "Жюль Верн", "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 273, DateTimeKind.Utc).AddTicks(8290), null, null, "Very good book", "https://j.livelib.ru/boocover/1001542410/o/1833/Zhyul_Vern__Puteshestvie_k_tsentru_Zemli.jpeg", true, false, false, false, 2.0, "Путешествие к центру земли", null, null, 1 },
                    { 5, "Джоан Роулинг", "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 273, DateTimeKind.Utc).AddTicks(8293), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/86/25/86251214-92ea-44e9-a394-1a9ef1211400.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и философский камень", null, null, 1 },
                    { 6, "Джоан Роулинг", "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 273, DateTimeKind.Utc).AddTicks(8303), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/37/81/37811194-8ad9-45a1-b394-9960b57b511f.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и кубок огня книга", null, null, 2 },
                    { 7, "Джоан Роулинг", "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 273, DateTimeKind.Utc).AddTicks(8307), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/db/53/db53dd7e-10da-471a-b33e-2669f5a5abe9.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и орден феникса", null, null, 2 },
                    { 8, "Федор Достоевский", "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 273, DateTimeKind.Utc).AddTicks(8312), null, null, "Very good book", "https://azbyka.ru/fiction/wp-content/uploads/2013/02/55.jpg", true, false, false, false, 3.0, "Идиот", null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 273, DateTimeKind.Utc).AddTicks(9114), null, null, false, "I think this is amazing book!", null, null, 2 },
                    { 2, 6, "ebs", new DateTime(2020, 3, 27, 14, 57, 1, 274, DateTimeKind.Utc).AddTicks(1359), null, null, false, "This is awful book...", null, null, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DialogControls",
                keyColumn: "Id",
                keyValue: 1);

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
                keyValue: new Guid("c51777ca-e0bf-4b3e-9fe2-14cb19603a10"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("da9ec19d-9654-4004-8adb-07d9916a3109"));

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
            //    values: new object[] { new Guid("0ccc5a70-953e-4dbc-93c7-b79e2d273c0a"), "ebs", new DateTime(2020, 1, 26, 12, 51, 5, 478, DateTimeKind.Utc).AddTicks(4435), null, null, false, "admin", null, null });

            //migrationBuilder.InsertData(
            //    table: "Roles",
            //    columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
            //    values: new object[] { new Guid("7848f4a7-c00f-44a6-a4bf-28d72c882c1b"), "ebs", new DateTime(2020, 1, 26, 12, 51, 5, 478, DateTimeKind.Utc).AddTicks(8348), null, null, false, "user", null, null });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
            //    values: new object[] { 1, null, "ebs", new DateTime(2020, 1, 26, 12, 51, 5, 479, DateTimeKind.Utc).AddTicks(1796), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("0ccc5a70-953e-4dbc-93c7-b79e2d273c0a"), null, null });

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
            //    values: new object[] { 2, null, "ebs", new DateTime(2020, 1, 26, 12, 51, 5, 488, DateTimeKind.Utc).AddTicks(7259), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("7848f4a7-c00f-44a6-a4bf-28d72c882c1b"), null, null });
        }
    }
}
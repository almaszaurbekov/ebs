using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedClickCountToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: new Guid("2b7a277d-1ded-4dfd-bd80-1b4433c7e6b8"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("f00f2d1d-1929-4cad-914a-5bc4e6ad35a3"));

            migrationBuilder.AddColumn<int>(
                name: "СlickCount",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DialogControls",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastMessageDate" },
                values: new object[] { new DateTime(2020, 4, 24, 16, 22, 26, 391, DateTimeKind.Utc).AddTicks(5162), new DateTime(2020, 4, 24, 16, 22, 26, 391, DateTimeKind.Utc).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 4, 24, 16, 22, 26, 392, DateTimeKind.Utc).AddTicks(1631));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 4, 24, 16, 22, 26, 392, DateTimeKind.Utc).AddTicks(4864));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0a5eaa61-4e75-4646-b175-c1137f69db7d"), "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 383, DateTimeKind.Utc).AddTicks(7694), null, null, false, "admin", null, null },
                    { new Guid("c5666b99-240b-49e4-89ac-549b80f4054d"), "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 383, DateTimeKind.Utc).AddTicks(9691), null, null, false, "user", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 384, DateTimeKind.Utc).AddTicks(1890), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("0a5eaa61-4e75-4646-b175-c1137f69db7d"), null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 389, DateTimeKind.Utc).AddTicks(3904), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("c5666b99-240b-49e4-89ac-549b80f4054d"), null, null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "ImageSource", "InGoodCondition", "IsBorrowed", "IsDeleted", "IsPainted", "Rate", "Title", "UpdatedBy", "UpdatedDate", "UserId", "СlickCount" },
                values: new object[,]
                {
                    { 4, "Жюль Верн", "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 390, DateTimeKind.Utc).AddTicks(9733), null, null, "Very good book", "https://j.livelib.ru/boocover/1001542410/o/1833/Zhyul_Vern__Puteshestvie_k_tsentru_Zemli.jpeg", true, false, false, false, 2.0, "Путешествие к центру земли", null, null, 1, 0 },
                    { 3, "Жюль Верн", "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 390, DateTimeKind.Utc).AddTicks(9729), null, null, "Very good book", "https://be2.aldebaran.ru/static/bookimages/42/41/09/42410912.bin.dir/42410912.cover.jpg", true, false, false, false, 3.0, "Вокруг света за 80 дней", null, null, 1, 0 },
                    { 2, "Жюль Верн", "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 390, DateTimeKind.Utc).AddTicks(9604), null, null, "Very good book", "https://www.mann-ivanov-ferber.ru/assets/images/covers/37/21737/1.00x-thumb.png", true, false, false, false, 4.0, "Дети капитана Гранта", null, null, 1, 0 },
                    { 1, "Жюль Верн", "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 390, DateTimeKind.Utc).AddTicks(2987), null, null, "Very good book", "https://static.librebook.me/uploads/pics/01/61/852.jpg", true, false, false, false, 3.0, "20 тысяч лье под водой", null, null, 1, 0 },
                    { 5, "Джоан Роулинг", "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 390, DateTimeKind.Utc).AddTicks(9735), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/86/25/86251214-92ea-44e9-a394-1a9ef1211400.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и философский камень", null, null, 1, 0 },
                    { 6, "Джоан Роулинг", "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 390, DateTimeKind.Utc).AddTicks(9743), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/37/81/37811194-8ad9-45a1-b394-9960b57b511f.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и кубок огня книга", null, null, 2, 0 },
                    { 7, "Джоан Роулинг", "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 390, DateTimeKind.Utc).AddTicks(9746), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/db/53/db53dd7e-10da-471a-b33e-2669f5a5abe9.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и орден феникса", null, null, 2, 0 },
                    { 8, "Федор Достоевский", "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 390, DateTimeKind.Utc).AddTicks(9749), null, null, "Very good book", "https://azbyka.ru/fiction/wp-content/uploads/2013/02/55.jpg", true, false, false, false, 3.0, "Идиот", null, null, 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 391, DateTimeKind.Utc).AddTicks(1716), null, null, false, "I think this is amazing book!", null, null, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 2, 6, "ebs", new DateTime(2020, 4, 24, 16, 22, 26, 391, DateTimeKind.Utc).AddTicks(3128), null, null, false, "This is awful book...", null, null, 1 });
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
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

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
                keyValue: new Guid("0a5eaa61-4e75-4646-b175-c1137f69db7d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("c5666b99-240b-49e4-89ac-549b80f4054d"));

            migrationBuilder.DropColumn(
                name: "СlickCount",
                table: "Books");

            migrationBuilder.UpdateData(
                table: "DialogControls",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastMessageDate" },
                values: new object[] { new DateTime(2020, 4, 3, 10, 29, 35, 888, DateTimeKind.Utc).AddTicks(2484), new DateTime(2020, 4, 3, 10, 29, 35, 888, DateTimeKind.Utc).AddTicks(5764) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 4, 3, 10, 29, 35, 888, DateTimeKind.Utc).AddTicks(6832));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 4, 3, 10, 29, 35, 889, DateTimeKind.Utc).AddTicks(951));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2b7a277d-1ded-4dfd-bd80-1b4433c7e6b8"), "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 882, DateTimeKind.Utc).AddTicks(2883), null, null, false, "admin", null, null },
                    { new Guid("f00f2d1d-1929-4cad-914a-5bc4e6ad35a3"), "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 882, DateTimeKind.Utc).AddTicks(4836), null, null, false, "user", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 882, DateTimeKind.Utc).AddTicks(6935), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("2b7a277d-1ded-4dfd-bd80-1b4433c7e6b8"), null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 887, DateTimeKind.Utc).AddTicks(2691), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("f00f2d1d-1929-4cad-914a-5bc4e6ad35a3"), null, null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "ImageSource", "InGoodCondition", "IsBorrowed", "IsDeleted", "IsPainted", "Rate", "Title", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 4, "Жюль Верн", "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 887, DateTimeKind.Utc).AddTicks(9928), null, null, "Very good book", "https://j.livelib.ru/boocover/1001542410/o/1833/Zhyul_Vern__Puteshestvie_k_tsentru_Zemli.jpeg", true, false, false, false, 2.0, "Путешествие к центру земли", null, null, 1 },
                    { 3, "Жюль Верн", "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 887, DateTimeKind.Utc).AddTicks(9924), null, null, "Very good book", "https://be2.aldebaran.ru/static/bookimages/42/41/09/42410912.bin.dir/42410912.cover.jpg", true, false, false, false, 3.0, "Вокруг света за 80 дней", null, null, 1 },
                    { 2, "Жюль Верн", "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 887, DateTimeKind.Utc).AddTicks(9800), null, null, "Very good book", "https://www.mann-ivanov-ferber.ru/assets/images/covers/37/21737/1.00x-thumb.png", true, false, false, false, 4.0, "Дети капитана Гранта", null, null, 1 },
                    { 1, "Жюль Верн", "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 887, DateTimeKind.Utc).AddTicks(3884), null, null, "Very good book", "https://static.librebook.me/uploads/pics/01/61/852.jpg", true, false, false, false, 3.0, "20 тысяч лье под водой", null, null, 1 },
                    { 5, "Джоан Роулинг", "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 887, DateTimeKind.Utc).AddTicks(9931), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/86/25/86251214-92ea-44e9-a394-1a9ef1211400.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и философский камень", null, null, 1 },
                    { 6, "Джоан Роулинг", "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 887, DateTimeKind.Utc).AddTicks(9937), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/37/81/37811194-8ad9-45a1-b394-9960b57b511f.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и кубок огня книга", null, null, 2 },
                    { 7, "Джоан Роулинг", "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 887, DateTimeKind.Utc).AddTicks(9939), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/db/53/db53dd7e-10da-471a-b33e-2669f5a5abe9.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и орден феникса", null, null, 2 },
                    { 8, "Федор Достоевский", "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 887, DateTimeKind.Utc).AddTicks(9942), null, null, "Very good book", "https://azbyka.ru/fiction/wp-content/uploads/2013/02/55.jpg", true, false, false, false, 3.0, "Идиот", null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 888, DateTimeKind.Utc).AddTicks(444), null, null, false, "I think this is amazing book!", null, null, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 2, 6, "ebs", new DateTime(2020, 4, 3, 10, 29, 35, 888, DateTimeKind.Utc).AddTicks(1758), null, null, false, "This is awful book...", null, null, 1 });
        }
    }
}

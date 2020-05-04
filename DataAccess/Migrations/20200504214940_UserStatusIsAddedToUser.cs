using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UserStatusIsAddedToUser : Migration
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
                keyValue: new Guid("23b1fb71-0252-40d3-ae2a-918e132d38fd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("94821232-58b5-4fe4-8161-242d33991ec0"));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DialogControls",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastMessageDate" },
                values: new object[] { new DateTime(2020, 5, 4, 21, 49, 39, 419, DateTimeKind.Utc).AddTicks(9931), new DateTime(2020, 5, 4, 21, 49, 39, 420, DateTimeKind.Utc).AddTicks(5680) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 5, 4, 21, 49, 39, 421, DateTimeKind.Utc).AddTicks(989));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 5, 4, 21, 49, 39, 421, DateTimeKind.Utc).AddTicks(5944));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("150ecd30-ddae-49ea-b9b5-67ad30eb1d90"), "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 407, DateTimeKind.Utc).AddTicks(1222), null, null, false, "admin", null, null },
                    { new Guid("5e04882c-3bf5-4ce0-a63f-579477cdffae"), "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 407, DateTimeKind.Utc).AddTicks(4105), null, null, false, "user", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 408, DateTimeKind.Utc).AddTicks(1296), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("150ecd30-ddae-49ea-b9b5-67ad30eb1d90"), 0, null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 415, DateTimeKind.Utc).AddTicks(5015), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("5e04882c-3bf5-4ce0-a63f-579477cdffae"), 0, null, null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "ImageSource", "InGoodCondition", "IsBorrowed", "IsDeleted", "IsPainted", "Rate", "Title", "UpdatedBy", "UpdatedDate", "UserId", "СlickCount" },
                values: new object[,]
                {
                    { 4, "Жюль Верн", "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 417, DateTimeKind.Utc).AddTicks(6674), null, null, "Very good book", "https://j.livelib.ru/boocover/1001542410/o/1833/Zhyul_Vern__Puteshestvie_k_tsentru_Zemli.jpeg", true, false, false, false, 2.0, "Путешествие к центру земли", null, null, 1, 20 },
                    { 3, "Жюль Верн", "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 417, DateTimeKind.Utc).AddTicks(6669), null, null, "Very good book", "https://be2.aldebaran.ru/static/bookimages/42/41/09/42410912.bin.dir/42410912.cover.jpg", true, false, false, false, 3.0, "Вокруг света за 80 дней", null, null, 1, 15 },
                    { 2, "Жюль Верн", "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 417, DateTimeKind.Utc).AddTicks(6444), null, null, "Very good book", "https://www.mann-ivanov-ferber.ru/assets/images/covers/37/21737/1.00x-thumb.png", true, false, false, false, 4.0, "Дети капитана Гранта", null, null, 1, 20 },
                    { 1, "Жюль Верн", "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 416, DateTimeKind.Utc).AddTicks(7390), null, null, "Very good book", "https://static.librebook.me/uploads/pics/01/61/852.jpg", true, false, false, false, 3.0, "20 тысяч лье под водой", null, null, 1, 30 },
                    { 5, "Джоан Роулинг", "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 417, DateTimeKind.Utc).AddTicks(6680), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/86/25/86251214-92ea-44e9-a394-1a9ef1211400.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и философский камень", null, null, 1, 35 },
                    { 6, "Джоан Роулинг", "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 417, DateTimeKind.Utc).AddTicks(6689), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/37/81/37811194-8ad9-45a1-b394-9960b57b511f.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и кубок огня книга", null, null, 2, 56 },
                    { 7, "Джоан Роулинг", "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 417, DateTimeKind.Utc).AddTicks(6694), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/db/53/db53dd7e-10da-471a-b33e-2669f5a5abe9.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и орден феникса", null, null, 2, 23 },
                    { 8, "Федор Достоевский", "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 417, DateTimeKind.Utc).AddTicks(6697), null, null, "Very good book", "https://azbyka.ru/fiction/wp-content/uploads/2013/02/55.jpg", true, false, false, false, 3.0, "Идиот", null, null, 2, 76 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 418, DateTimeKind.Utc).AddTicks(4566), null, null, false, "I think this is amazing book!", null, null, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 2, 6, "ebs", new DateTime(2020, 5, 4, 21, 49, 39, 418, DateTimeKind.Utc).AddTicks(7021), null, null, false, "This is awful book...", null, null, 1 });
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
                keyValue: new Guid("150ecd30-ddae-49ea-b9b5-67ad30eb1d90"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("5e04882c-3bf5-4ce0-a63f-579477cdffae"));

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "DialogControls",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LastMessageDate" },
                values: new object[] { new DateTime(2020, 5, 3, 20, 19, 25, 190, DateTimeKind.Utc).AddTicks(6863), new DateTime(2020, 5, 3, 20, 19, 25, 191, DateTimeKind.Utc).AddTicks(1450) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2020, 5, 3, 20, 19, 25, 191, DateTimeKind.Utc).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2020, 5, 3, 20, 19, 25, 192, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("94821232-58b5-4fe4-8161-242d33991ec0"), "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 181, DateTimeKind.Utc).AddTicks(5328), null, null, false, "admin", null, null },
                    { new Guid("23b1fb71-0252-40d3-ae2a-918e132d38fd"), "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 181, DateTimeKind.Utc).AddTicks(8030), null, null, false, "user", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 182, DateTimeKind.Utc).AddTicks(1071), null, null, "foxxychmoxy@gmail.com", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("94821232-58b5-4fe4-8161-242d33991ec0"), null, null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "ImageSource", "IsDeleted", "LastName", "Password", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 2, null, "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 188, DateTimeKind.Utc).AddTicks(1991), null, null, "almasgaara@mail.ru", null, null, false, null, "d9edce5cc424444d5c03fb834de779e9924eb69d05ea3f7be7dd5041bb87864e18b1b75c4d7a9b4abd9d9c784dc482701bdb711256c1f93610a107a161ceb2c2", new Guid("23b1fb71-0252-40d3-ae2a-918e132d38fd"), null, null });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Description", "ImageSource", "InGoodCondition", "IsBorrowed", "IsDeleted", "IsPainted", "Rate", "Title", "UpdatedBy", "UpdatedDate", "UserId", "СlickCount" },
                values: new object[,]
                {
                    { 4, "Жюль Верн", "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 189, DateTimeKind.Utc).AddTicks(9536), null, null, "Very good book", "https://j.livelib.ru/boocover/1001542410/o/1833/Zhyul_Vern__Puteshestvie_k_tsentru_Zemli.jpeg", true, false, false, false, 2.0, "Путешествие к центру земли", null, null, 1, 20 },
                    { 3, "Жюль Верн", "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 189, DateTimeKind.Utc).AddTicks(9529), null, null, "Very good book", "https://be2.aldebaran.ru/static/bookimages/42/41/09/42410912.bin.dir/42410912.cover.jpg", true, false, false, false, 3.0, "Вокруг света за 80 дней", null, null, 1, 15 },
                    { 2, "Жюль Верн", "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 189, DateTimeKind.Utc).AddTicks(9306), null, null, "Very good book", "https://www.mann-ivanov-ferber.ru/assets/images/covers/37/21737/1.00x-thumb.png", true, false, false, false, 4.0, "Дети капитана Гранта", null, null, 1, 20 },
                    { 1, "Жюль Верн", "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 189, DateTimeKind.Utc).AddTicks(605), null, null, "Very good book", "https://static.librebook.me/uploads/pics/01/61/852.jpg", true, false, false, false, 3.0, "20 тысяч лье под водой", null, null, 1, 30 },
                    { 5, "Джоан Роулинг", "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 189, DateTimeKind.Utc).AddTicks(9539), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/86/25/86251214-92ea-44e9-a394-1a9ef1211400.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и философский камень", null, null, 1, 35 },
                    { 6, "Джоан Роулинг", "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 189, DateTimeKind.Utc).AddTicks(9550), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/37/81/37811194-8ad9-45a1-b394-9960b57b511f.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и кубок огня книга", null, null, 2, 56 },
                    { 7, "Джоан Роулинг", "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 189, DateTimeKind.Utc).AddTicks(9554), null, null, "Very good book", "https://i4.mybook.io/p/512x852/book_covers/db/53/db53dd7e-10da-471a-b33e-2669f5a5abe9.jpe?v2", true, false, false, false, 3.0, "Гарри Поттер и орден феникса", null, null, 2, 23 },
                    { 8, "Федор Достоевский", "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 189, DateTimeKind.Utc).AddTicks(9557), null, null, "Very good book", "https://azbyka.ru/fiction/wp-content/uploads/2013/02/55.jpg", true, false, false, false, 3.0, "Идиот", null, null, 2, 76 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, 1, "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 190, DateTimeKind.Utc).AddTicks(2261), null, null, false, "I think this is amazing book!", null, null, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Text", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 2, 6, "ebs", new DateTime(2020, 5, 3, 20, 19, 25, 190, DateTimeKind.Utc).AddTicks(4111), null, null, false, "This is awful book...", null, null, 1 });
        }
    }
}

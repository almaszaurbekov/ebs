using Common;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccess.Context
{
    public class SeedData
    {
        public static ModelBuilder Initialize(ModelBuilder modelBuilder)
        {
            // Добавление пользователей с правами доступа
            string adminRoleName = "admin";
            string userRoleName = "user";
            string password = "123qweAS1!";

            Role adminRole = new Role 
            { 
                Id = Guid.NewGuid(), 
                Name = adminRoleName 
            };
            Role userRole = new Role 
            { 
                Id = Guid.NewGuid(), 
                Name = userRoleName 
            };

            User adminUser = new User 
            { 
                Id = 1, 
                Email = "foxxychmoxy@gmail.com", 
                Password = PasswordHelper.Hash(password), 
                RoleId = adminRole.Id 
            };
            User simpleUser = new User 
            { 
                Id = 2, 
                Email = "almasgaara@mail.ru", 
                Password = PasswordHelper.Hash(password), 
                RoleId = userRole.Id 
            };

            // Добавление книг для двух пользователей
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    UserId = adminUser.Id,
                    Author = "Жюль Верн",
                    Title = "20 тысяч лье под водой",
                    ImageSource = "https://static.librebook.me/uploads/pics/01/61/852.jpg",
                    Rate = 3,
                    Description = "Very good book",
                    IsBorrowed = false,
                    IsPainted = false,
                    InGoodCondition = true
                },
                new Book()
                {
                    Id = 2,
                    UserId = adminUser.Id,
                    Author = "Жюль Верн",
                    Title = "Дети капитана Гранта",
                    ImageSource = "https://www.mann-ivanov-ferber.ru/assets/images/covers/37/21737/1.00x-thumb.png",
                    Rate = 4,
                    Description = "Very good book",
                    IsBorrowed = false,
                    IsPainted = false,
                    InGoodCondition = true
                },
                new Book()
                {
                    Id = 3,
                    UserId = adminUser.Id,
                    Author = "Жюль Верн",
                    Title = "Вокруг света за 80 дней",
                    ImageSource = "https://be2.aldebaran.ru/static/bookimages/42/41/09/42410912.bin.dir/42410912.cover.jpg",
                    Rate = 3,
                    Description = "Very good book",
                    IsBorrowed = false,
                    IsPainted = false,
                    InGoodCondition = true
                },
                new Book()
                {
                    Id = 4,
                    UserId = adminUser.Id,
                    Author = "Жюль Верн",
                    Title = "Путешествие к центру земли",
                    ImageSource = "https://j.livelib.ru/boocover/1001542410/o/1833/Zhyul_Vern__Puteshestvie_k_tsentru_Zemli.jpeg",
                    Rate = 2,
                    Description = "Very good book",
                    IsBorrowed = false,
                    IsPainted = false,
                    InGoodCondition = true
                },
                new Book()
                {
                    Id = 5,
                    UserId = adminUser.Id,
                    Author = "Джоан Роулинг",
                    Title = "Гарри Поттер и философский камень",
                    ImageSource = "https://i4.mybook.io/p/512x852/book_covers/86/25/86251214-92ea-44e9-a394-1a9ef1211400.jpe?v2",
                    Rate = 3,
                    Description = "Very good book",
                    IsBorrowed = false,
                    IsPainted = false,
                    InGoodCondition = true
                },
                new Book()
                {
                    Id = 6,
                    UserId = simpleUser.Id,
                    Author = "Джоан Роулинг",
                    Title = "Гарри Поттер и кубок огня книга",
                    ImageSource = "https://i4.mybook.io/p/512x852/book_covers/37/81/37811194-8ad9-45a1-b394-9960b57b511f.jpe?v2",
                    Rate = 3,
                    Description = "Very good book",
                    IsBorrowed = false,
                    IsPainted = false,
                    InGoodCondition = true
                },
                new Book()
                {
                    Id = 7,
                    UserId = simpleUser.Id,
                    Author = "Джоан Роулинг",
                    Title = "Гарри Поттер и орден феникса",
                    ImageSource = "https://i4.mybook.io/p/512x852/book_covers/db/53/db53dd7e-10da-471a-b33e-2669f5a5abe9.jpe?v2",
                    Rate = 3,
                    Description = "Very good book",
                    IsBorrowed = false,
                    IsPainted = false,
                    InGoodCondition = true
                },
                new Book()
                {
                    Id = 8,
                    UserId = simpleUser.Id,
                    Author = "Федор Достоевский",
                    Title = "Идиот",
                    ImageSource = "https://azbyka.ru/fiction/wp-content/uploads/2013/02/55.jpg",
                    Rate = 3,
                    Description = "Very good book",
                    IsBorrowed = false,
                    IsPainted = false,
                    InGoodCondition = true
                }
            };

            // Добавление комментариев двум книгам от двух пользователей
            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {
                    Id = 1,
                    BookId = 1,
                    UserId = 2,
                    Text = "I think this is amazing book!"
                },
                new Comment()
                {
                    Id = 2,
                    BookId = 6,
                    UserId = 1,
                    Text = "This is awful book..."
                }
            };

            // Добавление сообщений от двух пользователей (переписка между собой)
            // Добавление диалога - контроль над сообщениями
            DialogControl dialog = new DialogControl()
            {
                Id = 1,
                FirstInterlocutorEmail = adminUser.Email,
                FirstInterlocutorId = adminUser.Id,
                SecondInterlocutorEmail = simpleUser.Email,
                SecondInterlocutorId = simpleUser.Id,
                LastMessage = "Hello! Yes, I know. Thank you!",
                LastMessageDate = DateTime.UtcNow
            };
            List<Message> messages = new List<Message>()
            {
                new Message()
                {
                    Id = 1,
                    DialogControlId = dialog.Id,
                    Text = "Hi! You are beautiful.",
                    HasRead = true,
                    UserSenderEmail = adminUser.Email,
                    UserSenderId = adminUser.Id,
                    UserReceiverEmail = simpleUser.Email,
                    UserReceiverId = simpleUser.Id
                },
                new Message()
                {
                    Id = 2,
                    DialogControlId = dialog.Id,
                    Text = "Hello! Yes, I know. Thank you!",
                    HasRead = true,
                    UserSenderEmail = simpleUser.Email,
                    UserSenderId = simpleUser.Id,
                    UserReceiverEmail = adminUser.Email,
                    UserReceiverId = adminUser.Id
                }
            };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, simpleUser });
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<Comment>().HasData(comments);
            modelBuilder.Entity<DialogControl>().HasData(dialog);
            modelBuilder.Entity<Message>().HasData(messages);

            return modelBuilder;
        }
    }
}

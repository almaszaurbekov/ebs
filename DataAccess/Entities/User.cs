using Common;
using DataAccess.Entities.Base;
using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
    public class User : AuditableEntity<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageSource { get; set; }
        public string Address { get; set; }
        public List<Book> Books { get; set; }
        public Guid RoleId { get; set; }
        public UserStatus Status { get; set; }
        public Role Role { get; set; }
        public List<DialogControl> Dialogs { get; set; }

        public User()
        {
            Books = new List<Book>();
            Dialogs = new List<DialogControl>();
        }
    }
}
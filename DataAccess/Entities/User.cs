using DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

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
        public List<Book> ELibrary { get; set; }
    }
}

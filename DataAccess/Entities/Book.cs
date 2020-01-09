using DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Book : Entity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public double Rate { get; set; }
        public string ImageSource { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

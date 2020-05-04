using DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class BookOperationsLog : LogEntity<int>
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public int BookId { get; set; }
    }
}

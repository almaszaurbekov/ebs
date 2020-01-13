using DataAccess.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Comment : AuditableEntity<int>
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}

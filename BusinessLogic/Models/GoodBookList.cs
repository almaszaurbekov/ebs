using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models
{
    /// <summary>
    /// Список книг в хорошем состоянии
    /// </summary>
    public class GoodBookList
    {
        public string Author { get; set; }
        public string BookName { get; set; }
        public string LastCommentText { get; set; }
        public DateTime LastCommnetTime { get; set; }
    }
}

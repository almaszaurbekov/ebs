using System;
namespace DataAccess.Models
{
    /// <summary>
    /// Список книг в хорошем состоянии
    /// </summary>
    public class GoodBookList
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string LastCommentText { get; set; }
        public DateTime? LastCommentTime { get; set; }
    }
}
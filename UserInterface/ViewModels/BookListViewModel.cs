using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string UserEmail { get; set; }
        public int UserId { get; set; }
        public string ImageSource { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

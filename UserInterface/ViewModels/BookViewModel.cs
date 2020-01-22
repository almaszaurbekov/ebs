using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using UserInterface.Mappings;

namespace UserInterface.ViewModels.Entities
{
    public class BookViewModel : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public IFormFile Image { get; set; }
        public int UserId { get; set; }
        public int Rate { get; set; }
        public bool IsBorrowed { get; set; }
    }
}

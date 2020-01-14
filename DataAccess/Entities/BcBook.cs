using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public enum Genre {  }
    public class BcBook
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Rate { get; set; }
        public string Publisher { get; set; }
        public string PublishYear { get; set; }
        public string Code { get; set; }
        public string Pages { get; set; }
        public string Cover { get; set; }
        public string Size { get; set; }
        public string Thickness { get; set; }
        public string Weight { get; set; }
        public string Image { get; set; }
        public int GenreId { get; set; }
    }
}
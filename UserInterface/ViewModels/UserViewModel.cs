using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using UserInterface.Mappings;

namespace UserInterface.ViewModels.Entities
{
    public class UserViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Email { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string LastName { get; set; }

        public IFormFile Image { get; set; }

        public string ImageSource { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        public string Address { get; set; }

        public bool RemoveImage { get; set; }
    }
}

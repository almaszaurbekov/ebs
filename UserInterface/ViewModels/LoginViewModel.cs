using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using UserInterface.Mappings;

namespace UserInterface.ViewModels
{
    public class LoginViewModel : IMapFrom<User>
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

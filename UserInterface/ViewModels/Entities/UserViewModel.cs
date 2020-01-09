using DataAccess.Entities;
using UserInterface.Mappings;

namespace UserInterface.ViewModels.Entities
{
    public class UserViewModel : IMapFrom<User>
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
}

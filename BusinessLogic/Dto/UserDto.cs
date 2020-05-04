using BusinessLogic.Dto.Base;
using Common;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Dto
{
    public class UserDto : DtoModel<int>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageSource { get; set; }
        public string Address { get; set; }
        public List<BookDto> Books { get; set; }
        public Guid RoleId { get; set; }
        public RoleDto Role { get; set; }
        public UserStatus Status { get; set; }
        public List<DialogControlDto> Dialogs { get; set; }

        public UserDto()
        {
            Books = new List<BookDto>();
            Dialogs = new List<DialogControlDto>();
        }
    }
}
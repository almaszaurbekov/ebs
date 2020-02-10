using BusinessLogic.Dto.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Dto
{
    public class RoleDto : DtoModel<Guid>
    {
        public string Name { get; set; }
        public List<UserDto> Users { get; set; }
        public RoleDto()
        {
            Users = new List<UserDto>();
        }
    }
}

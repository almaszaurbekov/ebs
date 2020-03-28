using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    public class UserListViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName 
        { 
            get { return FirstName + " " + LastName; } 
        }
        public string ImageSource { get; set; }
        public string RoleName { get; set; }
        public string Address { get; set; }
    }
}

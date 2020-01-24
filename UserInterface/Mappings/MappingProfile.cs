using AutoMapper;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UserInterface.ViewModels;
using UserInterface.ViewModels.Entities;

namespace UserInterface.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserViewModel>(MemberList.Source);
            CreateMap<UserViewModel, User>(MemberList.None);

            CreateMap<Book, BookViewModel>(MemberList.Source);
            CreateMap<BookViewModel, Book>(MemberList.None);

            CreateMap<Book, BookListViewModel>(MemberList.Source);
            CreateMap<BookListViewModel, Book>(MemberList.None);

            CreateMap<DialogControl, DialogViewModel>(MemberList.Source);

            CreateMap<BcBook, Book>(MemberList.Source);

            CreateMap<BookTransaction, BookTransactionViewModel>(MemberList.Source);
            CreateMap<BookTransactionViewModel, BookTransaction>(MemberList.None);
        }
    }
}

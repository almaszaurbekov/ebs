using AutoMapper;
using BusinessLogic.Dto;
using DataAccess.Entities;
using UserInterface.ViewModels;
using UserInterface.ViewModels.Entities;

namespace UserInterface.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserViewModel>(MemberList.Source);
            CreateMap<UserViewModel, UserDto>(MemberList.None);

            //

            CreateMap<Book, BookViewModel>(MemberList.Source);
            CreateMap<BookViewModel, Book>(MemberList.None);
            CreateMap<Book, BookListViewModel>(MemberList.Source);
            CreateMap<BookListViewModel, Book>(MemberList.None);
            CreateMap<BcBook, Book>(MemberList.Source);

            CreateMap<BookTransaction, BookTransactionViewModel>(MemberList.Source);
            CreateMap<BookTransactionViewModel, BookTransaction>(MemberList.None);

            CreateMap<Message, MessageViewModel>(MemberList.Source);
            CreateMap<MessageViewModel, Message>(MemberList.None);

            CreateMap<DialogControl, DialogViewModel>(MemberList.Source);
            CreateMap<DialogViewModel, DialogControl>(MemberList.Source);
        }
    }
}
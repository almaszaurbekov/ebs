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

            CreateMap<BookDto, BookViewModel>(MemberList.Source);
            CreateMap<BookViewModel, BookDto>(MemberList.None);
            CreateMap<BookDto, BookListViewModel>(MemberList.Source);
            CreateMap<BookListViewModel, BookDto>(MemberList.None);
            CreateMap<BcBook, BookDto>(MemberList.Source);

            CreateMap<BookTransactionDto, BookTransactionViewModel>(MemberList.Source);
            CreateMap<BookTransactionViewModel, BookTransactionDto>(MemberList.None);

            //

            CreateMap<Message, MessageViewModel>(MemberList.Source);
            CreateMap<MessageViewModel, Message>(MemberList.None);

            CreateMap<DialogControl, DialogViewModel>(MemberList.Source);
            CreateMap<DialogViewModel, DialogControl>(MemberList.Source);
        }
    }
}
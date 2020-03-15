using AutoMapper;
using BusinessLogic.Dto;
using UserInterface.ViewModels;
using UserInterface.ViewModels.Entities;

namespace UserInterface.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserViewModel>(MemberList.Source);
            CreateMap<UserViewModel, UserDto>(MemberList.None);
            CreateMap<UserDto, UserListViewModel>(MemberList.Source);
            CreateMap<UserListViewModel, UserDto>(MemberList.None);

            CreateMap<BookDto, BookViewModel>(MemberList.Source);
            CreateMap<BookViewModel, BookDto>(MemberList.None);
            CreateMap<BookDto, BookListViewModel>(MemberList.Source);
            CreateMap<BookListViewModel, BookDto>(MemberList.None);
            CreateMap<BcBookDto, BookDto>(MemberList.Source);

            CreateMap<BookTransactionDto, BookTransactionViewModel>(MemberList.Source);
            CreateMap<BookTransactionViewModel, BookTransactionDto>(MemberList.None);

            CreateMap<MessageDto, MessageViewModel>(MemberList.Source);
            CreateMap<MessageViewModel, MessageDto>(MemberList.None);

            CreateMap<DialogControlDto, DialogViewModel>(MemberList.Source);
            CreateMap<DialogViewModel, DialogControlDto>(MemberList.Source);
        }
    }
}
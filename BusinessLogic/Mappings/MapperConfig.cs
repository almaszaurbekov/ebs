using AutoMapper;
using AutoMapper.Configuration;
using BusinessLogic.Dto;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Mappings
{
    internal static class MapperConfig
    {
        public static IMapper MapperInitialize()
        {
            var config = new MapperConfiguration(CreateMap());
            return config.CreateMapper();
        }

        private static MapperConfigurationExpression CreateMap()
        {
            var cfg = new MapperConfigurationExpression();

            cfg.CreateMap<UserDto, User>(MemberList.Source);
            cfg.CreateMap<User, UserDto>(MemberList.None);

            cfg.CreateMap<RoleDto, Role>(MemberList.Source);
            cfg.CreateMap<Role, RoleDto>(MemberList.None);

            cfg.CreateMap<BookDto, Book>(MemberList.Source);
            cfg.CreateMap<Book, BookDto>(MemberList.None);
            cfg.CreateMap<BcBookDto, BookDto>(MemberList.Source);

            cfg.CreateMap<BookTransactionDto, BookTransaction>(MemberList.Source);
            cfg.CreateMap<BookTransaction, BookTransactionDto>(MemberList.None);

            cfg.CreateMap<MessageDto, Message>(MemberList.Source);
            cfg.CreateMap<Message, MessageDto>(MemberList.None);

            cfg.CreateMap<CommentDto, Comment>(MemberList.Source);
            cfg.CreateMap<Comment, CommentDto>(MemberList.None);

            cfg.CreateMap<DialogControlDto, DialogControl>(MemberList.Source);
            cfg.CreateMap<DialogControl, DialogControlDto>(MemberList.Source);

            return cfg;
        }
    }
}
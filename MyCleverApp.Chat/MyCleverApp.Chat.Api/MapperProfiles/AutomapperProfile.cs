using AutoMapper;
using MyCleverApp.Chat.Api.Models.ContactList;
using MyCleverApp.Chat.Api.Models.Messages;
using MyCleverApp.Chat.Api.Models.Users;
using MyCleverApp.Chat.Dto;
using MyCleverApp.Chat.Dto.ContactList;
using MyCleverApp.Chat.Dto.Messages;
using MyCleverApp.Chat.Dto.Users;
using MyCleverApp.Chat.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCleverApp.Chat.Api.MapperProfiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            Users();
            Messages();
            ContactList();
        }

        public void Users ()
        {
            CreateMap<UserPostModel, CreateUserDto>()
                .ReverseMap();
            CreateMap<UserDto, User>()
                .ReverseMap();
        }

        public void Messages ()
        {
            CreateMap<PostMessage, SendMessageDto>()
                .ReverseMap();
        }

        public void ContactList ()
        {
            CreateMap<string, GetContactListsRequest>()
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src));
            CreateMap<ContactInfo, ContactInfoDto>()
                .ReverseMap();
            CreateMap<ContactList, ContactListDto>()
                .ReverseMap();

            CreateMap<CreateContactListModel, CreateContactListDto>()
                .ReverseMap();
        }
    }
}

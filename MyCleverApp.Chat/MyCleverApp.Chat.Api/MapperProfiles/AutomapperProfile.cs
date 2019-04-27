using AutoMapper;
using MyCleverApp.Chat.Api.Models.ContactList;
using MyCleverApp.Chat.Api.Models.Messages;
using MyCleverApp.Chat.Dto;
using MyCleverApp.Chat.Dto.ContactList;
using MyCleverApp.Chat.Dto.Messages;
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
            Messages();
            ContactList();
        }

        public void Messages ()
        {
            CreateMap<PostMessage, SendMessageDto>();
        }

        public void ContactList ()
        {
            CreateMap<string, GetContactListsRequest>()
                .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src));
            CreateMap<ContactInfo, ContactInfoDto>();
            CreateMap<ContactList, ContactListDto>()
                .ForMember(dst => dst.Contacts, opt => opt.MapFrom(src => src.ContactListContact.Select(c => c.ContactInfo)))
                .ReverseMap();

            CreateMap<CreateContactListModel, CreateContactListDto>();
        }
    }
}

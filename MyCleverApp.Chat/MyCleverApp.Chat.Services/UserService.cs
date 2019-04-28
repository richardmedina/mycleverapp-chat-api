using AutoMapper;
using MyCleverApp.Chat.Dto;
using MyCleverApp.Chat.Dto.Users;
using MyCleverApp.Chat.Model;
using MyCleverApp.Chat.Model.Entities;
using MyCleverApp.Chat.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyCleverApp.Chat.Services
{
    public class UserService : ServiceBase, IUserService
    {
        private readonly ChatDbContext _context;
        private readonly IMapper _mapper;
        public UserService(ChatDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ServiceResult<UserDto> CreateUser(CreateUserDto createUser)
        {
            if (_context.Users.Any(u => u.UserName == createUser.UserName))
                return GetFailedResult<UserDto>(createUser, new ErrorMessage { Text = "User Exists" });

            var user = new User
            {
                UserName = createUser.UserName,
                Password = createUser.Password,
                ContactInfo = new ContactInfo
                {
                    DisplayName = createUser.UserName,
                    DisplayImage = "NoDisplayImage"
                }
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var dto = _mapper.Map<UserDto>(user);
            return GetSuccessResult(createUser, dto);
        }

        public ServiceResult<IEnumerable<UserDto>> GetUsers()
        {
            return GetSuccessResult(null as ServiceRequest, _mapper.Map<IEnumerable<UserDto>>(_context.Users));
        }
    }
}

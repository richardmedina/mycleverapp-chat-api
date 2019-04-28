using MyCleverApp.Chat.Dto;
using MyCleverApp.Chat.Dto.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Services.Interfaces
{
    public interface IUserService
    {
        ServiceResult<UserDto> CreateUser(CreateUserDto createUser);
        ServiceResult<IEnumerable<UserDto>> GetUsers();
    }
}

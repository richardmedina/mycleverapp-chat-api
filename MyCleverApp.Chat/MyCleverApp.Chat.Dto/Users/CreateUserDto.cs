using System;
using System.Collections.Generic;
using System.Text;

namespace MyCleverApp.Chat.Dto.Users
{
    public class CreateUserDto : ServiceRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

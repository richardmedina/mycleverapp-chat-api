using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyCleverApp.Chat.Api.Models.Users;
using MyCleverApp.Chat.Dto.Users;
using MyCleverApp.Chat.Services;
using MyCleverApp.Chat.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCleverApp.Chat.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index ()
        {
            return Ok(_userService.GetUsers());
        }

        [HttpPost]
        public IActionResult Post ([FromBody] UserPostModel model)
        {
            var dto = _mapper.Map<CreateUserDto>(model);

            return Ok(_userService.CreateUser (dto));
        }
    }
}

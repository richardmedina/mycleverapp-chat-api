using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyCleverApp.Chat.Api.Models.Auth;
using MyCleverApp.Chat.Dto.Users;
using MyCleverApp.Chat.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyCleverApp.Chat.Api.Controllers
{
    [Route("[controller]")]
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public AuthController(IConfiguration configuration, IMapper mapper, IUserService userService)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Login ([FromBody] LoginModel loginModel)
        {
            await Task.Delay(0);

            return Ok(loginModel);
        }

        [Authorize]
        [HttpGet("protected")]
        public IActionResult Protected ()
        {
            return Ok("Protected is allowed");
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]LoginModel loginModel)
        {
            var dto = _mapper.Map<AuthenticateDto>(loginModel);
            var result = _userService.Authenticate(dto);
            var user = result.Result;

            if (result.Result == null)
            {
                return BadRequest("Invalid username or password");
            }                

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration.GetSection("Authentication").GetValue<string>("Secret");
            var key = Encoding.ASCII.GetBytes(secret);
            //var key = Encoding.ASCII.GetBytes("THIS IS USED TO SIGN AND VERIFY JWT TOKENS, REPLACE IT WITH YOUR OWN SECRET, IT CAN BE ANY STRING");// _appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                user.Id,
                user.UserName,
                Token = tokenString
            });
        }

    }
}

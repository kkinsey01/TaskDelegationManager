using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using TaskDelegationAPI.DTOs;
using TaskDelegationAPI.Services.Interfaces;

namespace TaskDelegationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("GetMe")]
        public IActionResult GetMe()
        {
            return Ok("Hello");
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(UserDTO newUser)
        {
            await _userService.AddNewUser(newUser);
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO userLogin)
        {
            var token = await _userService.Login(userLogin);
            if (token == null)
            {
                return Problem();
            }
            return Ok(new JwtSecurityTokenHandler().WriteToken(token)); 
        }

        [HttpPost("Scramble")]
        public async Task<IActionResult> Scramble()
        {
            await _userService.HashPasswords();
            return Ok();
        }

        [HttpPost("ModifyUser")]
        public async Task<IActionResult> ModifyUser(UserDTO modifiedUser)
        {
            await _userService.ModifyUser(modifiedUser);
            return Ok();
        }        


    }
}

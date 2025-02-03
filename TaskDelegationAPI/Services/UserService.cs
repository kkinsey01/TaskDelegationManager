using Microsoft.EntityFrameworkCore;
using TaskDelegationAPI.DTOs;
using ef = TaskDelegationAPI.Models;
using TaskDelegationAPI.Services.Interfaces;
using TaskDelegationAPI.Middleware;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TaskDelegationAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ef.TaskDelegationContext _context;
        private readonly IConfiguration _config;

        public UserService(IConfiguration config,ef.TaskDelegationContext context)
        {
            _context = context;
            _config = config;
        }

        public Task AddNewUser(UserDTO newUser)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUser(UserDTO userToDelete)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var users = await _context.Users.Select(s => new UserDTO
            {
                UserID = s.UserID,
                UserName = s.UserName,
                Email = s.Email,
                NumberOfTasks = s.NumberOfTasks,
                TasksComplete = s.TasksComplete,                
            }).ToListAsync();      
            return users;
        }

        public async Task HashPasswords()
        {
            var users = await _context.Users.Where(w => !w.Password.StartsWith("$2a$10")).ToListAsync();
            foreach (var user in users)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, 10);
            }

            await _context.SaveChangesAsync();
        }

        public Task ModifyUser(UserDTO modifiedUser)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetUser(string? username, string? firstName, string? lastName)
        {
            var userQuery = _context.Users.AsQueryable();
            if (username != null)
            {
                userQuery = userQuery.Where(w => w.UserName == username);
            }
            if (firstName != null)
            {
                userQuery = userQuery.Where(w => w.FirstName == firstName);
            }
            if (lastName != null)
            {
                userQuery = userQuery.Where(w => w.LastName == lastName);
            }
            var user = await userQuery.FirstOrDefaultAsync();
            if (user == null)
            {
                throw new TaskDelegationException("User Not Found");
            }
            var userToReturn = new UserDTO
            {
                UserID = user.UserID,
                UserName = user.UserName,
                Email = user.Email,
                NumberOfTasks = user.NumberOfTasks,
                TasksComplete = user.TasksComplete,
            };

            return userToReturn;
        }

        public async Task<JwtSecurityToken> Login(LoginDTO userLogin)
        {
            var user = await _context.Users.Where(w => (w.UserName == userLogin.UserName || w.Email == userLogin.UserName)).FirstOrDefaultAsync();            
            if (user == null)
            {
                throw new ValidationException("User not found or invalid credentials");
            }

            bool passwordMatch = BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password);
            if (!passwordMatch)
            {
                throw new ValidationException("Invalid Credentials");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _config["JWT:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("UserID", user.UserID.ToString()),
                new Claim("UserName", user.UserName),
                new Claim("Email", user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    _config["JWT:Issuer"],
                    _config["JWT:Audience"],
                    claims,                                         
                    expires: DateTime.Now.AddMinutes(90),
                    signingCredentials: signIn
                );
            
            return token;
        }
    }
}

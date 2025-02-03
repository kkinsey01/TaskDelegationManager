using System.IdentityModel.Tokens.Jwt;
using TaskDelegationAPI.DTOs;
using ef = TaskDelegationAPI.Models;

namespace TaskDelegationAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> GetUser(string? username, string? firstName, string? lastName);
        Task AddNewUser(UserDTO newUser);
        Task ModifyUser(UserDTO modifiedUser);
        Task DeleteUser(UserDTO userToDelete);
        Task HashPasswords();
        Task<JwtSecurityToken> Login(LoginDTO userLogin);
    }
}

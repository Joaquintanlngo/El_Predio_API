using Application.Models.Request;
using Application.Models.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        Task<string?> Login(LoginRequest request);
        Task<UserDto> GetUserById(int userId);
        Task UpdateUser(int userId, UpdateUserRequest request);
        Task DeleteUser(int userId);

        Task<Client> CreateUser(CreateUserRequest request);
    }
}

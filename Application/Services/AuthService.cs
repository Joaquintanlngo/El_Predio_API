using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Responses;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher _passwordHasher;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _passwordHasher = passwordHasher;
        }

        public async Task<string?> Login(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.Password))
            {
                return null;
            }

            return _tokenService.GenerateToken(user);
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            var user = await _userRepository.GetById(userId);

            if(user == null)
                throw new Exception("User not exist");

            return UserDto.Create(user);
        }

        public async Task<Client> CreateUser(CreateUserRequest request)
        {
            var hashedPassword = _passwordHasher.HashPassword(request.Password);
            var newUser = new Client
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = hashedPassword,
                PhoneNumber = request.PhoneNumber
            };

            await _userRepository.Create(newUser);
            return newUser;
        }

        public async Task UpdateUser(int userId, UpdateUserRequest request)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null)
                throw new Exception("User not exist");

            user.FullName = request.FullName ?? user.FullName;
            user.Email = request.Email?? user.Email;
            user.PhoneNumber = request.PhoneNumber ?? user.PhoneNumber;

            await _userRepository.Update(user);
            
        }

        public async Task DeleteUser(int userId)
        {
            var user = await _userRepository.GetById(userId);

            if (user == null)
                throw new Exception("User not exist");

            await _userRepository.Delete(user);
        }
    }
}

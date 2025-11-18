using AMI_Project.DTOs;
using AMI_Project.Models;
using AMI_Project_API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AMI_Project.Services
{
    public class AuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

       
        public async Task<User?> RegisterAsync(RegisterDto dto)
        {
            
            var users = await _unitOfWork.Users.GetAllAsync();
            if (users.Any(u => u.Email == dto.Email))
                return null;

            var user = new User
            {
                UserName = dto.Username,
                Email = dto.Email,
                Password = dto.Password, 
                Role = dto.Role
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();

            return user;
        }

       
        public async Task<User?> LoginAsync(LoginDto dto)
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            var user = users.FirstOrDefault(u => u.Email == dto.Email && u.Password == dto.Password);

            return user; 
        }
    }
}

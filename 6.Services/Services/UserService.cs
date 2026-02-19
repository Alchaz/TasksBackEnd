using Data.Repositories;
using Data.Repository;
using Domain.Entities;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Entities.Task;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }


        public IEnumerable<UserReadDto> ListUsers()
        {
            return _userRepository.Query()
                .Include(u => u.Tasks) 
                .Select(u => new UserReadDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Tasks = u.Tasks.Select(t => new TaskReadDto
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Description = t.Description,
                        DueDate = t.DueDate,
                        Status = t.Status,
                        UserId = t.UserId,
                        UserName = t.User.Username
                    }).ToList()
                })
                .ToList();
        }


        public UserReadDto GetUserById(int id)
        {
            var user = _userRepository.Query()
                .Include(u => u.Tasks)
                .FirstOrDefault(u => u.Id == id);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            return new UserReadDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Tasks = user.Tasks.Select(t => new TaskReadDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Status = t.Status,
                    UserId = t.UserId,
                    UserName = t.User.Username
                }).ToList()
            };
        }


        public void CreateUser(UserCreateDto dto)
        {
            var user = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
                
            };

            _userRepository.Add(user);
            _userRepository.SaveChanges();
        }

 
        public void UpdateUser(int id, UserUpdateDto dto)
        {
            var user = _userRepository.Query().FirstOrDefault(u => u.Id == id);

            if (user == null)
                throw new KeyNotFoundException("User not found");

            user.Username = dto.Username;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;

            _userRepository.SaveChanges();
        }

    }
}

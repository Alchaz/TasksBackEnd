
using Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserReadDto> ListUsers();
        UserReadDto GetUserById(int id);
        void CreateUser(UserCreateDto dto);
        void UpdateUser(int id, UserUpdateDto dto);
           
    }
}

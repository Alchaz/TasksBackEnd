using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public ICollection<TaskReadDto> Tasks { get; set; }
    }


    public class UserCreateDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }

    }


    public class UserUpdateDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public  class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }



    }
}

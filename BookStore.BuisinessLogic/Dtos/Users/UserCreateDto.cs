using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Dtos.Users
{
    public class UserCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Boolean UserBlocked { get; set; } = false;
    }
}

using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Interfaces
{
    public interface IAccountService
    {
        Task<User> AuthenticateUserAsync(string email, string password);
        Task<User> ValidateUserAsync(string email, string password);
    }
}

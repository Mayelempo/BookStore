using BookStore.BusinessLogic.Interfaces;
using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Services
{
    public class AccountService : IAccountService 
    {
        public Task<User> AuthenticateUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<User> ValidateUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}

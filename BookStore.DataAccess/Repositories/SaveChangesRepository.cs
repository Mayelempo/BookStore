using BookStore.DataAccess.DataContext;
using BookStore.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repositories
{
    public class SaveChangesRepository : ISaveChangesRepository
    {
        private readonly DatabaseContext _databaseContext;
        public SaveChangesRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public Task SaveChangesAsync()
        {
           return  _databaseContext.SaveChangesAsync();
        }
    }
}

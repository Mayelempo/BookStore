﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Interfaces
{
    public interface ISaveChangesRepository
    {
        Task SaveChangesAsync();
    }
}

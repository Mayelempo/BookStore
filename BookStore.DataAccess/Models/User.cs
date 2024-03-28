using BookStore.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Entities
{
    public class User: IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Boolean UserBlocked { get; set; } = false; 
        //Navigation properties used for setting relationships between tables
        public IList<Collection>? Collections { get; set; }
        public IList<Like>? Likes { get; set; }
        public IList<Comment>? Comments { get; set; }
    }
}

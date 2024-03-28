using BookStore.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Models
{
    public class Comment
    {
        public string Id { get; set; } = new Guid().ToString();
        public string CommentText { get; set; }
        public string ImageUrl { get; set; } 
        public DateTime CreationDateTime { get; set; }
        //navigation properties
        public Book? Book { get; set; }
        public string Book_Id { get; set; }
        public User? User { get; set; }
        public string User_Id { get; set; }
    }
}

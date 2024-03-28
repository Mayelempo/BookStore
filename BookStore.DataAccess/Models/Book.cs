
using BookStore.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.DataAccess.Entities
{
    public class Book
    {
        public string Id { get; set; } = new Guid().ToString();
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } 

        //Navigations Properties
        public Collection? Collection { get; set; }
        public string Collection_Id { get; set; }
        public IList<Like>? Likes { get;set; }
        public IList<Comment>? Comments { get; set; }      
     }
}

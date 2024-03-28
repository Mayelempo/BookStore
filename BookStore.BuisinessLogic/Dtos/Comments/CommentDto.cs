using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Dtos.Comments
{
    public class CommentDto
    {
        public string CommentText { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}

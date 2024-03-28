using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BusinessLogic.Dtos.Likes
{
    public class LikeDto
    {
        public Boolean Liked { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime CreationDateTime { get; set; }
    }
}

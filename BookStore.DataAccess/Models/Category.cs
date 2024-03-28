using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Models
{
    public class Category
    {
        public string Id { get; set; } = new Guid().ToString();
        public string Name { get; set; } = string.Empty;
        public IList<Collection>? Collections { get; set; }  
    }
}

using System;
using System.Collections.Generic;

namespace Recipe_Book.Models
{
    public partial class Types
    {
        public Types()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Recipe_Book.Models
{
    public partial class Type
    {
        public Type()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

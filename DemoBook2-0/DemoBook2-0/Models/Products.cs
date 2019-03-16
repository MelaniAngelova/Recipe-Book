using System;
using System.Collections.Generic;

namespace DemoBook2_0.Models
{
    public partial class Product
    {
        public Product()
        {
            RecipesProducts = new HashSet<RecipesProducts>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }

        public virtual ICollection<RecipesProducts> RecipesProducts { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Recipe_Book.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductsRecipes = new HashSet<ProductsRecipes>();
        }

        public int Id { get; }
        public string Name { get; set; }
        public int? TypeId { get; }
        public double? Price { get; }
        public string ImgName { get; set; }

        public virtual Types Type { get; set; }
        public virtual ICollection<ProductsRecipes> ProductsRecipes { get; set; }
    }
}

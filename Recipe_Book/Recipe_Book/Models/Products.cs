using System;
using System.Collections.Generic;

namespace Recipe_Book.Models
{
    public partial class Products
    {
        public Products()
        {
            ProductsRecipes = new HashSet<ProductsRecipes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }
        public double? Price { get; set; }
        public string ImgName { get; set; }

        public virtual Types Type { get; set; }
        public virtual ICollection<ProductsRecipes> ProductsRecipes { get; set; }
    }
}

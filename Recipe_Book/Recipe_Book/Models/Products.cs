using System;
using System.Collections.Generic;

namespace app.Models
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

        public virtual Types Type { get; set; }
        public virtual ICollection<ProductsRecipes> ProductsRecipes { get; set; }
    }
}

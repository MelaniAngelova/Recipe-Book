using System;
using System.Collections.Generic;

namespace RecipeBook.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductsRecipes = new HashSet<ProductsRecipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }
        public double? Price { get; set; }

        public virtual Type Type { get; set; }
        public virtual ICollection<ProductsRecipe> ProductsRecipes { get; set; }
    }
}

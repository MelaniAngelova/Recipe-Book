using System;
using System.Collections.Generic;

namespace Recipe_Book.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            ProductsRecipes = new HashSet<ProductsRecipe>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ImgName { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductsRecipe> ProductsRecipes { get; set; }
    }
}

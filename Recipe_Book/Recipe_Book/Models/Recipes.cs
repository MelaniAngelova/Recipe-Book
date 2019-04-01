using System;
using System.Collections.Generic;

namespace app.Models
{
    public partial class Recipes
    {
        public Recipes()
        {
            ProductsRecipes = new HashSet<ProductsRecipes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string ImgName { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<ProductsRecipes> ProductsRecipes { get; set; }
    }
}

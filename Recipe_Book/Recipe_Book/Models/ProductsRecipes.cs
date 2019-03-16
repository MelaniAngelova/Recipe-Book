using System;
using System.Collections.Generic;

namespace Recipe_Book.Models
{
    public partial class ProductsRecipes
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? RecipeId { get; set; }
        public int? Quantity { get; set; }

        public virtual Products Product { get; set; }
        public virtual Recipes Recipe { get; set; }
    }
}

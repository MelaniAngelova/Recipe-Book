using System;
using System.Collections.Generic;

namespace Recipe_Book.Models
{
    public partial class ProductsRecipe
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? RecipeId { get; set; }
        public int? Quantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}

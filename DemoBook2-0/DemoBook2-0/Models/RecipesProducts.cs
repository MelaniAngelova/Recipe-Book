using System;
using System.Collections.Generic;

namespace DemoBook2_0.Models
{
    public partial class RecipesProducts
    {
        public int Id { get; set; }
        public int? RecipeId { get; set; }
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}

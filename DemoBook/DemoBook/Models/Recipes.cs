using System;
using System.Collections.Generic;

namespace DemoBook.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipesProducts = new HashSet<RecipesProducts>();
        }

        public int Id { get; set; }
        public string RecipeName { get; set; }
        public string Decription { get; set; }
        public byte? Favorites { get; set; }
        public string Difficulty { get; set; }
        public byte? MyRecipes { get; set; }

        public virtual ICollection<RecipesProducts> RecipesProducts { get; set; }
    }
}

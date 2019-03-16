using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoBook.Models;

namespace DemoBook.Controller
{
    class Controller
    {
        public Controller()
        {
        }

        private recipe_bookContext context;

        public List<Recipe> GetAllRecipes()
        {
            using (context = new recipe_bookContext())
            {
                return context.Recipes.ToList();
            }
        }

        public void AddRecipe(Recipe recipe)
        {
            using (context = new recipe_bookContext())
            {
                context.Recipes.Add(recipe);
                context.Products.Add(recipe.)
            }
        }
    }
}

using DemoBook2_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBook2_0.Controller
{
    class LogicController
    {
        public LogicController()
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
            }
        }
    }
}

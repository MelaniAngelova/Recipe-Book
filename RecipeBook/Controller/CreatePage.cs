using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecipeBook.Models;
using RecipeBook.Controller;
using System.Collections.ObjectModel;
using System.Security.AccessControl;

namespace RecipeBook.Controller
{
    public class CreatePage
    {
        recipebookContext context = new recipebookContext();
        public CreatePage()
        {

        }

        private int recipeId;

        public void ManageInput(ObservableCollection<string> newProducts, params string[] args)
        {
            Recipe recipe = new Recipe();
            recipe.Name = args[0];
            recipe.Description = args[1];
            recipe.CategoryId = context.Categories.Where(x => x.Name == args[2]).Select(x => x.Id).ToList().First();
            if (args.Count() >= 4) { recipe.ImgName = args[3]; }

            context.Recipes.Add(recipe);
            context.SaveChanges();

            recipeId = context.Recipes.Where(x => x.Name == args[0]).Select(x => x.Id).ToList().First();
            Uri dest = new Uri("ms-appx:///Assets/RecipeImages/" + args[3]);
            //System.IO.File.Copy(args[4], args[4]);
        }

        public int GetLastRecipeId()
        {
            return recipeId;
        }
    }
}

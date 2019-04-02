using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RecipeBook.Models;
using RecipeBook.Controller;

namespace RecipeBook.Controller
{
    class CreatePage
    {
        recipebookContext context = new recipebookContext();

        public CreatePage()
        {

        }

        public List<string> ManageInput(params string[] args)
        {
            Recipe recipe = new Recipe();
            recipe.Name = args[0];
            recipe.Description = args[1];
            var category = context.Categories.Where(x => x.Name == args[2]).First();
            recipe.CategoryId = category.Id;
            if (args.Count() >= 5) { recipe.ImgName = args[4]; }
            var products = args[3].Split(new char[2] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var newProducts = new List<string>();
            foreach (var productName in products)
            {
                if(context.Products.Any(p => p.Name == productName) == false)
                {
                  newProducts.Add(productName);
                }
                newProducts.Add(productName);
            }

            return newProducts;
        }
    }
}

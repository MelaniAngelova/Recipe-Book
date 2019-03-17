using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Recipe_Book.Models;

namespace Recipe_Book.Controller
{
    class Controller
    {
        recipebookContext context = new recipebookContext();

        private void AddRecipe(Recipe recipe, List<Product> products)
        {
            if(context.Recipes.Where(x => x.Name == recipe.Name) == null)
            {
                context.Recipes.Add(recipe);
                foreach (var product in products)
                {
                    if (context.Products.Where(x => x.Name == product.Name) == null)
                    {
                        context.Products.Add(product);
                    }
                    else { }
                }
                context.SaveChanges();
                foreach (var product in products)
                {
                    ProductsRecipes productsRecipes = new ProductsRecipes();
                    productsRecipes.RecipeId = recipe.Id;
                    productsRecipes.ProductId = product.Id;
                    context.ProductsRecipes.Add(productsRecipes);
                }
            }
            else { }
        }

        private Recipe GetRecipeByName(int id)
        {
            return context.Recipes.First();
        }
    }
}

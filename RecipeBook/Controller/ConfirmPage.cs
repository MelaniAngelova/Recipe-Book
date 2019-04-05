using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBook.Controller
{
    class ConfirmPage
    {
        recipebookContext context = new recipebookContext();
        Controller mainController = new Controller();
        public ConfirmPage()
        {

        }

        public void AddProductsRecipesRelations(List<ProductToConfirm> products, int recipeId)
        {
            foreach(var prod in products)
            {
                if (CheckProduct(prod.Name))
                {
                    Product updatedProduct = new Product();
                    updatedProduct.Name = prod.Name;
                    if(prod.ProductType != "Липсва информация")
                    {
                        updatedProduct.TypeId = context.Types.Where(x => x.Name == prod.ProductType).Select(x => x.Id).ToList().First();
                    }
                    if (prod.ProductPrice != "Липсва информация")
                    {
                        updatedProduct.Price = double.Parse(prod.ProductPrice);
                    }
                    mainController.UpdateProduct(updatedProduct);
                }
                else
                {
                    Product newProduct = new Product();
                    newProduct.Name = prod.Name; if (prod.ProductType != "Липсва информация")
                    {
                        newProduct.TypeId = context.Types.Where(x => x.Name == prod.ProductType).Select(x => x.Id).ToList().First();
                    }
                    if (prod.ProductPrice != "Липсва информация")
                    {
                        newProduct.Price = double.Parse(prod.ProductPrice);
                    }
                    context.Products.Add(newProduct);
                    context.SaveChanges();
                }
            }

            foreach(var prod in products)
            {
                ProductsRecipe productsRecipe = new ProductsRecipe();
                productsRecipe.RecipeId = recipeId;
                productsRecipe.ProductId = context.Products.Where(x => x.Name == prod.Name).Select(x => x.Id).ToList().First();
                if (prod.ProductQuantity != "Липсва информация")
                {
                    productsRecipe.Quantity = int.Parse(prod.ProductQuantity);
                }
                context.ProductsRecipes.Add(productsRecipe);
                context.SaveChanges();
            }
            

            //if (context.Recipes.Where(x => x.Name == recipe.Name) == null)
            //{
            //    context.Recipes.Add(recipe);
            //    foreach (var product in products)
            //    {
            //        if (context.Products.Where(x => x.Name == product.Name) == null)
            //        {
            //            context.Products.Add(product);
            //        }
            //        else { }
            //    }
            //    context.SaveChanges();
            //    foreach (var product in products)
            //    {
            //        ProductsRecipe productsRecipes = new ProductsRecipe();
            //        productsRecipes.RecipeId = recipe.Id;
            //        productsRecipes.ProductId = product.Id;
            //        context.ProductsRecipes.Add(productsRecipes);
            //    }
            //}
            //else { }
        }

        private bool CheckProduct(string name)
        {
            bool check = false;
            try
            {
                if (context.Products.Where(x => x.Name == name).Select(x => x.Name).ToList().First() != null)
                {
                    check = true;
                }
            }
            catch (InvalidOperationException)
            {
                check = false;
            }
            return check;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

using RecipeBook.Models;

namespace RecipeBook.Controller
{
    class Controller
    {
        public Controller()
        {

        }

        recipebookContext context = new recipebookContext();
        
        public void UpdateProduct(Product product)
        {
            var oldProductId = context.Products.Where(x => x.Name == product.Name).Select(x => x.Id).ToList().First();
            var oldProduct = context.Products.Find(oldProductId);
            oldProduct.TypeId = product.TypeId;
            oldProduct.Price = product.Price;
            context.SaveChanges();
        }
    }
}

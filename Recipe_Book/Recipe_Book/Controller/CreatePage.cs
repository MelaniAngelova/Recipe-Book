using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Recipe_Book.Models;
using Recipe_Book.Controller;

namespace Recipe_Book.Controller
{
    class CreatePage
    {
        recipebookContext context = new recipebookContext();

        public CreatePage()
        {
                
        }

        public void ManageInput(params string[] args)
        {
            Recipe recipe = new Recipe();
            recipe.Name = args[0];
            //var category = context.Categories.Where(x => x.Name == args[2]).First();
            //recipe.CategoryId = category.Id;
            if (args.Count() >= 5) { recipe.ImgName = args[4]; }
            var products = args[3].Split(new char[2] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            
        }
    }
}

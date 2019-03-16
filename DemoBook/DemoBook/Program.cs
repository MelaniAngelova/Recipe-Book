using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DemoBook.Controller;
using DemoBook.Models;

namespace DemoBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.Controller controller = new Controller.Controller();

            List<Recipe> recipes = controller.GetAllRecipes();

            foreach(var recipe in recipes)
            {
                Console.WriteLine(recipe.RecipeName);
            }
        }
    }
}

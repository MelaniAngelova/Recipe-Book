using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RecipeBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public partial class RecipeDispHome
    {
        public RecipeDispHome(string name, string description, string categoryName, string imgAddress)
        {
            this.Name = name;
            this.Description = description;
            this.CategoryName = categoryName;
            this.ImgAddress = imgAddress;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImgAddress { get; set; }

    }

    public sealed partial class HomePage : Page
    {
        recipebookContext context = new recipebookContext();
        ObservableCollection<RecipeDispHome> recipes = new ObservableCollection<RecipeDispHome>();

        public HomePage()
        {
            this.InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            Random random = new Random();

            int[] randomRecipesId = new int[5];
            for (int i = 0; i < 5; i++)
            {
                randomRecipesId[i] = random.Next(10, 50);
            }

            foreach (var id in randomRecipesId)
            {
                var recipeToShow = context.Recipes.Where(x => x.Id == id).First();
                var categoryName = context.Categories.Where(x => x.Id == recipeToShow.CategoryId).Select(x => x.Name).ToList().First().ToString();
                string ImgAddress;
                if (recipeToShow.ImgName != "")
                {
                    ImgAddress = "/Assets/RecipeImages/" + recipeToShow.ImgName;
                }
                else
                {
                    ImgAddress = "/Assets/RecipeImages/NoImagePreview.png";
                }
                RecipeDispHome recipeDisp = new RecipeDispHome(recipeToShow.Name, recipeToShow.Description, categoryName, ImgAddress);
                recipes.Add(recipeDisp);
            }
        }

        private void RecipesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

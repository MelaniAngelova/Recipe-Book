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

    public partial class RecipeDisp
    {
        public RecipeDisp(string name, string description, string categoryName, string imgAddress)
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

    public sealed partial class SearchRecipe : Page
    {
        recipebookContext context = new recipebookContext();
        ObservableCollection<RecipeDisp> recipes = new ObservableCollection<RecipeDisp>();

        public SearchRecipe()
        {
            this.InitializeComponent();
        }

        private void BtnSearchForRecipes_Click(object sender, RoutedEventArgs e)
        {
            recipes.Clear();
            var recipesToShow = context.Recipes.Where(x => x.Name.Contains(RecipeNameInput.Text)).ToList();
            foreach (var recipe in recipesToShow)
            {
                var categoryName = context.Categories.Where(x => x.Id == recipe.CategoryId).Select(x => x.Name).ToList().First().ToString();
                string ImgAddress;
                if(recipe.ImgName != "")
                {                    
                    ImgAddress = "/Assets/RecipeImages/" + recipe.ImgName;
                }
                else
                {
                    ImgAddress = "/Assets/RecipeImages/NoImagePreview.png";
                }
                RecipeDisp recipeDisp = new RecipeDisp(recipe.Name, recipe.Description, categoryName, ImgAddress);
                recipes.Add(recipeDisp);
            }
            if(recipes.Count == 0)
            {
                NoResultsText.Visibility = Visibility.Visible;
            }
            else
            {
                NoResultsText.Visibility = Visibility.Collapsed;
            }
        }

        private void RecipesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RecipeDisp recipeChosen = (RecipeDisp)recipesList.SelectedItem;
            string recipeName = recipeChosen.Name;
            Recipe recipe = context.Recipes.Where(x => x.Name == recipeName).First();
            Frame.Navigate(typeof(RecipeInfo), recipe);
        }
    }
}

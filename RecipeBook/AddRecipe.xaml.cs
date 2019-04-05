using System;
using System.Collections.Generic;
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
using Windows.Storage.Pickers;
using Windows.Storage;

using RecipeBook.Models;
using RecipeBook.Controller;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RecipeBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddRecipe : Page
    {
        recipebookContext context = new recipebookContext();

        ObservableCollection<string> categories = new ObservableCollection<string>();
        ObservableCollection<string> newProducts = new ObservableCollection<string>();

        string ImgPath;
        
        public AddRecipe()
        {
            this.InitializeComponent();
            GetCategories();            
        }

        private void GetCategories()
        {
            List<string> categoriesNames = context.Categories.Select(x => x.Name).ToList();
            foreach(var name in categoriesNames)
            {
                categories.Add(name);
            }
        }
        
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            CreatePage createPage = new CreatePage();
            createPage.ManageInput(newProducts, RecipeName.Text, RecipeDescription.Text, RecipeCategory.SelectedValue.ToString(), ImgName.Text, ImgPath);
            var recipeid = createPage.GetLastRecipeId();
            newProducts.Insert(0, recipeid.ToString());
            Frame.Navigate(typeof(ConfirmRecipe), newProducts);
            
            
        }    

        private void BtnConfirmAddingProduct_Click(object sender, RoutedEventArgs e)
        {
            newProducts.Add(AutoSuggestBoxProducts.Text);
            AutoSuggestBoxProducts.Text = "";
            scrollViewProducts.Visibility = Visibility.Visible;
            btnProductAdd.Flyout.Hide();
        }

        private async void BtnImgLoad_ClickAsync(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();

            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");
            picker.ViewMode = PickerViewMode.Thumbnail;

            StorageFile pickedFile = await picker.PickSingleFileAsync();
            if (pickedFile != null)
            {
                ImgName.Text = pickedFile.Name;
                ImgPath = pickedFile.Path;
            }
        }

        private void AutoSuggestBoxProducts_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                ObservableCollection<string> products = new ObservableCollection<string>();
                var productsToHint = context.Products.Where(x => x.Name.Contains(AutoSuggestBoxProducts.Text)).ToList();
                foreach(var prod in productsToHint)
                {
                    products.Add(prod.Name);
                }

                sender.ItemsSource = products;
            }
        }

        private void AutoSuggestBoxProducts_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = args.SelectedItem.ToString();
        }
        
        private void BtnProductDelete_Click(object sender, RoutedEventArgs e)
        {
            newProducts.Remove(ProductsListView.SelectedItem.ToString());
            btnProductDelete.IsEnabled = false;
            if(newProducts.Count == 0)
            {
                scrollViewProducts.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnProductClear_Click(object sender, RoutedEventArgs e)
        {
            newProducts.Clear();
            scrollViewProducts.Visibility = Visibility.Collapsed;
        }

        private void ProductsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnProductDelete.IsEnabled = true;
        }

    }
}

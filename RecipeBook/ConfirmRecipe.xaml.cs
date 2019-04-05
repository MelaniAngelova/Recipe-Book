using RecipeBook.Controller;
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
    public class ProductToConfirm
    {
        recipebookContext context = new recipebookContext();

        private string name;
        private string productType;
        private int productQuantity;
        private double productPrice;

        public string Name { get; set; }
        public string ProductType { get; set; }
        public string ProductQuantity { get; set; }
        public string ProductPrice { get; set; }

        public ProductToConfirm(string name)
        {
            this.Name = name;
            if (CheckProduct(name))
            {
                var typeIdNum = context.Products.Where(x => x.Name == name).Select(x => x.TypeId).ToList().First();
                this.productType = context.Types.Where(x => x.Id == typeIdNum).Select(x => x.Name).ToList().First();
                this.ProductType = productType;
                var prodPrice = context.Products.Where(x => x.Name == name).Select(x => x.Price).ToList().First();
                this.productPrice = prodPrice.Value;
                this.ProductPrice = productPrice.ToString();
                this.productQuantity = 1;
                this.ProductQuantity = productQuantity.ToString();
            }
            else
            {
                this.ProductType = "Липсва информация";                
                this.ProductPrice = "Липсва информация";
                this.ProductQuantity = "Липсва информация";                
            }
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

    public sealed partial class ConfirmRecipe : Page
    {
        recipebookContext context = new recipebookContext();
        ObservableCollection<string> newProducts = new ObservableCollection<string>();
        ObservableCollection<string> types = new ObservableCollection<string>();
        ObservableCollection<ProductToConfirm> products = new ObservableCollection<ProductToConfirm>();

        ProductToConfirm originalProduct;
        ProductToConfirm changedProduct;
        int recipeId;

        public ConfirmRecipe()
        {
            this.InitializeComponent();
            GetTypes();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            newProducts = (ObservableCollection<string>)e.Parameter;
            recipeId = int.Parse(newProducts[0]);
            newProducts.RemoveAt(0);

            foreach(var product in newProducts)
            {
                products.Add(new ProductToConfirm(product));
            }
        }

        public ObservableCollection<string> GetTypes()
        {
            List<string> typesToGet = context.Types.Select(x => x.Name).ToList();
            
            foreach(var item in typesToGet)
            {
                types.Add(item);
            }
            return types;
        }
        
        private void BtnProductClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AutoSuggestBoxProducts_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                ObservableCollection<string> products = new ObservableCollection<string>();
                var productsToHint = context.Products.Where(x => x.Name.Contains(AutoSuggestBoxProducts.Text)).ToList();
                foreach (var prod in productsToHint)
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
        
        private void ProductsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnProductChange.IsEnabled = true;
        }

        private void BtnProductChange_Click(object sender, RoutedEventArgs e)
        {
            originalProduct = (ProductToConfirm)ProductsList.SelectedItem;
            AutoSuggestBoxProducts.PlaceholderText = originalProduct.Name;
            if(originalProduct.ProductType != "Липсва информация")
            {
                ProductType.PlaceholderText = originalProduct.ProductType;
            }
            if (originalProduct.ProductQuantity != "Липсва информация")
            {
                ProductQuantity.PlaceholderText = originalProduct.ProductQuantity;
            }
            if (originalProduct.ProductPrice != "Липсва информация")
            {
                ProductPrice.PlaceholderText = originalProduct.ProductPrice;
            }
        }

        private void BtnConfirmChanges_Click(object sender, RoutedEventArgs e)
        {
            changedProduct = originalProduct;
            if(AutoSuggestBoxProducts.Text != "")
            {
                changedProduct.Name = AutoSuggestBoxProducts.Text;
            }
            else
            {
                changedProduct.Name = originalProduct.Name;
            }
            try
            {
                if (ProductType.SelectedValue.ToString() != "")
                {
                    changedProduct.ProductType = ProductType.SelectedValue.ToString();
                }
            }
            catch (NullReferenceException)
            {
                changedProduct.ProductType = originalProduct.ProductType;
            }
            if(ProductQuantity.Text != "")
            {
                changedProduct.ProductQuantity = ProductQuantity.Text;
            }
            else
            {
                changedProduct.ProductQuantity = originalProduct.ProductQuantity;
            }
            if (ProductPrice.Text != "")
            {
                changedProduct.ProductPrice = ProductPrice.Text;
            }
            else
            {
                changedProduct.ProductPrice = originalProduct.ProductPrice;
            }            
            products.Remove((ProductToConfirm)ProductsList.SelectedItem);
            products.Add(changedProduct);
            btnProductChange.IsEnabled = false;
            btnProductChange.Flyout.Hide();
        }
        
        private void BtnProductChangesCancel_Click(object sender, RoutedEventArgs e)
        {
            btnProductChange.Flyout.Hide();
        }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            ConfirmPage confirmPage = new ConfirmPage();
            List<ProductToConfirm> productsToAdd = new List<ProductToConfirm>();
            foreach(var item in products)
            {
                productsToAdd.Add(item);
            }
            confirmPage.AddProductsRecipesRelations(productsToAdd, recipeId);
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            btnFinish.Flyout.Hide();
            Frame.Navigate(typeof(HomePage));
        }
    }
}

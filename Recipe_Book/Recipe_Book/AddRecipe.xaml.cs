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

using Recipe_Book.Models;
using Recipe_Book.Controller;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Recipe_Book
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddRecipe : Page
    {
        public AddRecipe()
        {
            this.InitializeComponent();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

            AdditionalCreatePanel.Visibility = Visibility.Visible;
            CreatePage createPage = new CreatePage();
            createPage.ManageInput(RecipeName.Text, RecipeDescription.Text, RecipeCategory.Text, RecipeProducts.Text, ImgName.Text);

        }

        private async void BtnImgLoad_ClickAsync(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();

            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".png");
            picker.ViewMode = PickerViewMode.Thumbnail;

            StorageFile pickedFile = await picker.PickSingleFileAsync();
            if(pickedFile != null)
            {
                ImgName.Text = pickedFile.Name;
            }
        }
    }
}

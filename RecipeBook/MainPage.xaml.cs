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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RecipeBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Ей тва ни е конструктора
        public MainPage()
        {
            this.InitializeComponent();
            PageName.Text = "Начална страница";
            MainFrame.Navigate(typeof(HomePage));
        }

        private void Menu_button_Click(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void PagesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (HomePageItem.IsSelected)
            {
                MainFrame.Navigate(typeof(HomePage));
                PageName.Text = "Начална страница";
            }

            else if (LookupPageItem.IsSelected)
            {
                MainFrame.Navigate(typeof(SearchRecipe));
                PageName.Text = "Потърси рецепта";
            }

            else if (CreatePageItem.IsSelected)
            {
                MainFrame.Navigate(typeof(AddRecipe));
                PageName.Text = "Добави рецепта";
            }
        }
    }
}

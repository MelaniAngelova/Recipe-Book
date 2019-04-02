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
        }


        private void AddRecipe_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Добавяне на рецепта
            Екран.Navigate(typeof(AddRecipe));

        }

        private void SearchRecipe_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Търсене на рецепта
           // Екран.Navigate(typeof(AddRecipe));

        }

        private void FavoriteRecipe_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Любими рецепти
            //Екран.Navigate(typeof(AddRecipe));

        }

        // Mega Fix
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MenuContainer.IsPaneOpen = !MenuContainer.IsPaneOpen;
        }
    }
}

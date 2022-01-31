using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.
//
// References:
// 1. Navigating in a WinUI 3 Desktop application | XAML Brewer, by Diederik Krols
//    https://xamlbrewer.wordpress.com/2021/07/06/navigating-in-a-winui-3-desktop-application/

namespace Lunar.WinUI3Playground
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            MainNavigationView.Loaded += MainNavigationView_Loaded;
            MainNavigationView.ItemInvoked += MainNavigationView_ItemInvoked;
        }

        public void SetCurrentNavigationViewItem(string menuItemTag, object parameter)
        {
            var selectedMenuItem = MainNavigationView.MenuItems
                .Cast<NavigationViewItem>()
                .FirstOrDefault(i => (string)i.Tag == menuItemTag);

            if (selectedMenuItem != null)
            {
                SetCurrentNavigationViewItem(selectedMenuItem, parameter);
            }
        }

        public void SetCurrentNavigationViewItem(NavigationViewItem item, object parameter)
        {
            if (item == null || item.Tag == null) return;

            ContentFrame.Navigate(Type.GetType($"Lunar.WinUI3Playground.Pages.{item.Tag}Page"), parameter);
            MainNavigationView.Header = item.Content;
            MainNavigationView.SelectedItem = item;
        }

        void MainNavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            SetCurrentNavigationViewItem((NavigationViewItem)sender.SelectedItem, null);
        }

        void MainNavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            SetCurrentNavigationViewItem("Twitter", null);
        }

        void MainNavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
        }
    }
}

using Lunar.WinUI3Playground.ViewModels;
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

namespace Lunar.WinUI3Playground.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TwitterPage : Page
    {
        private TwitterPageViewModel _viewModel;

        public TwitterPage()
        {
            this.InitializeComponent();

            Loaded += HomePage_Loaded;

            _viewModel = new TwitterPageViewModel();
            this.DataContext = _viewModel;
        }

        async void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.FetchTweetsAsync("#GenshinImpact");
        }

        async void TwitterSearch_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            string searchQuery = ((TextBox)sender).Text;

            if (e.Key == Windows.System.VirtualKey.Enter && !string.IsNullOrWhiteSpace(searchQuery))
            {
                await _viewModel.FetchTweetsAsync(searchQuery);
            }
        }

        void TweetCoverImage_Tapped(object sender, TappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        void ViewImageInBrowser_Click(object sender, RoutedEventArgs e)
        {
            var selectedMenuFlyoutItem = (MenuFlyoutItem)sender;

            var mainWindow = (MainWindow)(Application.Current as App).MainWindow;
            mainWindow.SetCurrentNavigationViewItem("WebView", selectedMenuFlyoutItem.Tag);
        }
    }
}

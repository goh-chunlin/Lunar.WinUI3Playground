using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace Lunar.WinUI3Playground.ViewModels
{
    public class WebViewPageViewModel : ObservableObject
    {
        private string _webUrl = "about:blank";

        public string WebUrl
        {
            get => _webUrl;
            private set => SetProperty(ref _webUrl, value);
        }

        public void NavigateToUrl(string url)
        {
            WebUrl = url;
        }
    }
}

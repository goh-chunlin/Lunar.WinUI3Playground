using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Core;

namespace Lunar.WinUI3Playground.Services
{
    public static class ThemeSelectorService
    {
        private const string SettingsKey = "AppBackgroundRequestedTheme";

        public static ElementTheme Theme { get; set; } = ElementTheme.Default;

        public static void Initialize()
        {
            Theme = LoadThemeFromSettings();

            SetRequestedTheme();
        }

        public static void SetTheme(ElementTheme theme)
        {
            Theme = theme;

            SetRequestedTheme();
            SaveThemeInSettings(Theme);
        }

        public static void SetRequestedTheme()
        {
            ((FrameworkElement)((MainWindow)(Application.Current as App).MainWindow).Content).RequestedTheme = Theme;
        }

        private static ElementTheme LoadThemeFromSettings()
        {
            ElementTheme cacheTheme = ElementTheme.Default;
            string themeName = (string)ApplicationData.Current.LocalSettings.Values[SettingsKey];

            if (!string.IsNullOrEmpty(themeName))
            {
                _ = Enum.TryParse(themeName, out cacheTheme);
            }

            return cacheTheme;
        }

        private static void SaveThemeInSettings(ElementTheme theme)
        {
            ApplicationData.Current.LocalSettings.Values[SettingsKey] = theme.ToString();
        }
    }
}

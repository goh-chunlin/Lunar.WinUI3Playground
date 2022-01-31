using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunar.WinUI3Playground.Models
{
    public class Tweet
    {
        public long Id { get; set; }

        public string Text { get; set; }

        public int NumberOfLikes { get; set; }

        public int NumberOfRetweets { get; set; }

        public string CoverImageUrl { get; set; } = "https://gclstorage.blob.core.windows.net/images/twitter.png";

        public List<Image> Images { get; set; } = new List<Image>();

        public string Author { get; set; }

        public Visibility FlyoutVisibility => Images.Count() > 0 ? Visibility.Visible : Visibility.Collapsed;
    }
}

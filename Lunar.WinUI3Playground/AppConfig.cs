using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace Lunar.WinUI3Playground
{
    // References:
    // 1. 'The configuration file 'appsettings.json' was not found and is not optional.
    //    The physical path is 'C:\Windows\SysWOW64\appsettings.json'.'
    //    https://stackoverflow.com/questions/67355916/the-configuration-file-appsettings-json-was-not-found-and-is-not-optional-th
    // 2. Using appsettings.json in UWP
    //    https://blog.mzikmund.com/2019/11/using-appsettings-json-in-uwp/


    public class AppConfig
    {
        private readonly IConfigurationRoot _configurationRoot;

        public AppConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Package.Current.InstalledLocation.Path)
                .AddJsonFile("appsettings.json", optional: false);

            _configurationRoot = builder.Build();
        }

        public TwitterConfig TwitterConfiguration 
        {
            get 
            {
                var config = _configurationRoot.GetSection(nameof(TwitterConfig)).GetChildren();

                var twitterConfig = new TwitterConfig 
                {
                    ConsumerApiKey = config.First(c => c.Key == "ConsumerApiKey").Value,
                    ConsumerApiSecret = config.First(c => c.Key == "ConsumerApiSecret").Value,
                    AccessToken = config.First(c => c.Key == "AccessToken").Value,
                    AccessTokenSecret = config.First(c => c.Key == "AccessTokenSecret").Value
                };

                return twitterConfig;
            }
        }

    }

    public class TwitterConfig
    {
        public string ConsumerApiKey { get; set; }

        public string ConsumerApiSecret { get; set; }

        public string AccessToken { get; set; }

        public string AccessTokenSecret { get; set; }
    }
}

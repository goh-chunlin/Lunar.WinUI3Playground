using Lunar.WinUI3Playground.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Tweetinvi;

namespace Lunar.WinUI3Playground.ViewModels
{
    public class TwitterPageViewModel : ObservableObject
    {
        private AppConfig _appConfig = new();
        private TwitterClient _twitterClient;

        private string _searchingQuery;
        private string _coverImageUrl;

        private ObservableCollection<Tweet> _tweets = new();

        public TwitterPageViewModel()
        {
            _twitterClient = new TwitterClient(
                _appConfig.TwitterConfiguration.ConsumerApiKey,
                _appConfig.TwitterConfiguration.ConsumerApiSecret,
                _appConfig.TwitterConfiguration.AccessToken,
                _appConfig.TwitterConfiguration.AccessTokenSecret);

            RefreshTweetsCommand = new AsyncRelayCommand(RefreshTweetsAsync);
        }

        public string SearchingQuery
        {
            get => _searchingQuery;
            private set => SetProperty(ref _searchingQuery, value);
        }

        public string CoverImageUrl
        {
            get => _coverImageUrl;
            private set => SetProperty(ref _coverImageUrl, value);
        }

        public IList<Tweet> Tweets => _tweets;

        public async Task FetchTweetsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return;

            if (!query.StartsWith("#")) query = "#" + query;

            _coverImageUrl = null;
            _tweets.Clear();

            var tweets = await _twitterClient.Search.SearchTweetsAsync(query);

            foreach (var tweet in tweets)
            {
                var newTweet = new Tweet
                {
                    Id = tweet.Id,
                    Text = tweet.FullText,
                    NumberOfLikes = tweet.FavoriteCount,
                    NumberOfRetweets = tweet.RetweetCount,
                    Author = tweet.CreatedBy.ScreenName
                };

                if (tweet.Media.Count() > 0)
                {
                    var photos = tweet.Media.Where(m => m.MediaType == "photo" || m.MediaType == "video");

                    int numberOfPhotos = photos.Count();
                    int i = 0;
                    foreach (var photo in photos)
                    {
                        if (i == 0)
                        {
                            newTweet.CoverImageUrl = photo.MediaURLHttps;

                            if (CoverImageUrl == null)
                            {
                                CoverImageUrl = photo.MediaURLHttps;
                            }
                        }

                        newTweet.Images.Add(new Image { 
                            Url = photo.MediaURLHttps,
                            Caption = $"Image {++i}/{numberOfPhotos}"
                        });
                    }

                    
                }

                _tweets.Add(newTweet);
            }

            SearchingQuery = query;
        }

        public ICommand RefreshTweetsCommand { get; }

        private async Task RefreshTweetsAsync() => await FetchTweetsAsync(_searchingQuery);
    }
}

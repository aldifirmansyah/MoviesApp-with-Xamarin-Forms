using MoviesApp.Models;
using MoviesApp.Services;
using MoviesApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviesApp
{
    public partial class MainPage : ContentPage
    {
        private MovieService _movieService = new MovieService();
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void MovieListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            Navigation.PushAsync(new MovieDetailsPage((e.SelectedItem as Movie).imdbID));
            movieListView.SelectedItem = null;
        }

        async private void SearchButton_Clicked(object sender, EventArgs e)
        {
            loadingIndicator.IsVisible = true;
            loadingIndicator.IsRunning = true;
            var s = searchBar.Text;
            if (string.IsNullOrWhiteSpace(s))
            {
                await DisplayAlert("Warning", "Please insert Title!", "OK");
            }

            else
            {
                ResponseWrapper result = await _movieService.GetMoviesByTitle(s);

                if (result.Response == "False")
                {
                    errorLabel.Text = result.Error;
                    movieListView.ItemsSource = new List<Movie>();
                    errorLabel.IsVisible = true;
                }

                else
                {
                    errorLabel.IsVisible = false;
                    movieListView.ItemsSource = result.ListOfMovie;
                }
            }
            loadingIndicator.IsRunning = false;
            loadingIndicator.IsVisible = false;
        }
    }
}

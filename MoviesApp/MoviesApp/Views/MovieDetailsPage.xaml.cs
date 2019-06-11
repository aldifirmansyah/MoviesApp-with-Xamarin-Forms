using MoviesApp.Models;
using MoviesApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieDetailsPage : ContentPage
	{
        private MovieService _movieService = new MovieService();
        private string _imdbID;
        public MovieDetailsPage (string imdbID)
		{
            _imdbID = imdbID;
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            Movie movieResult = await _movieService.GetMovieByImdbID(_imdbID);
            BindingContext = movieResult;
            loadingIndicator.IsVisible = false;

            base.OnAppearing();
        }
    }
}
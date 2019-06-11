using MoviesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Services
{
    public class MovieService
    {
        private const string _url = "http://www.omdbapi.com/?apikey=ac6e069a";
        private HttpClient _client = new HttpClient();

        public async Task<ResponseWrapper> GetMoviesByTitle(string title)
        {
            var result = await _client.GetStringAsync($"{_url}&s={title}");
            var responseWrapper = JsonConvert.DeserializeObject<ResponseWrapper>(result);
            return responseWrapper;
        }

        public async Task<Movie> GetMovieByImdbID(string imdbID)
        {
            var result = await _client.GetStringAsync($"{_url}&i={imdbID}");
            var movie = JsonConvert.DeserializeObject<Movie>(result);
            return movie;
        }
    }
}

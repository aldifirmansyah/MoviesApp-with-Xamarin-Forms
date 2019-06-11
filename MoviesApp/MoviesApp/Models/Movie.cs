using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.Models
{
    public class Movie
    {
        public string imdbID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Poster { get; set; }
        public string Plot { get; set; }
    }
}

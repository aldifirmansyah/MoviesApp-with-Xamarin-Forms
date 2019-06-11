using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesApp.Models
{
    public class ResponseWrapper
    {
        public string Response { get; set; }
        public string Error { get; set; }
        [JsonProperty("Search")]
        public List<Movie> ListOfMovie { get; set; }
    }
}

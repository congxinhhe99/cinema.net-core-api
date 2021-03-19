using cinema_core.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace cinema_core.Utils.MovieProxy
{
    public static class MovieProxy
    {
        public static MovieResponse GetMovieByIMDB(string imdb)
        {
           string result = new WebClient().DownloadString("http://www.omdbapi.com/?apikey=b9d9362f&i=" + imdb);
            MovieResponse movie = new MovieResponse();
             dynamic json = JsonConvert.DeserializeObject(result);
            movie.Imdb = imdb;
            movie.Title = (!string.IsNullOrEmpty(json["Title"]))? json["Title"]:"Title";
            movie.Country = (!string.IsNullOrEmpty(json["Country"]))? json["Country"]:"Country";
            movie.Poster = (!string.IsNullOrEmpty(json["Poster"]))? json["Poster"]:"Poster";
            movie.RateName = (!string.IsNullOrEmpty(json["Rated"]))? json["Rated"]:"Rated";

            string list = (!string.IsNullOrEmpty(json["Runtime"]))? json["Runtime"]:"Runtime";
            if (!list.Contains("N/A") && !list.Contains("Runtime"))
                movie.Runtime = int.Parse(list.Split(" min")[0]);
            else
                movie.Runtime = 0;

            list = (!string.IsNullOrEmpty(json["Director"])) ? json["Director"] : "Director";
            List<string> directors = list.Split(", ").ToList();
            movie.Directors = directors.ToArray();

            list = (!string.IsNullOrEmpty(json["Released"]))? json["Released"]:"Releaseed";
            movie.ReleasedAt = DateTime.Now; //DateTime.Parse(list);

            list = (!string.IsNullOrEmpty(json["Language"]))? json["Language"]:"Languge";
            List<string> languages = list.Split(", ").ToList();
            movie.Languages = languages.ToArray();

            list = (!string.IsNullOrEmpty(json["Actors"]))? json["Actors"]:"Actors";
            List<string> actors = list.Split(", ").ToList();
            movie.Actors = new List<Actor>();
            foreach(var name in actors)
            {
                Actor actor = new Actor()
                {
                    Name = name,
                    Avatar = "",
                };
                movie.Actors.Add(actor);
            }

            list = (!string.IsNullOrEmpty(json["Genre"]))? json["Genre"]:"Genre";
            List<string> genres = list.Split(", ").ToList();
            movie.Genres = new List<Genre>();
            foreach (var name in genres)
            {
                Genre genre = new Genre()
                {
                    Name = name,
                    Description = "",
                };
                movie.Genres.Add(genre);
            }

            return movie;
        }
    }
}

using Microsoft.AspNetCore.Http;
using Movies.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IHttpContextAccessor _httpContextAccessor;

        //public MovieApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        //{
        //    _httpClientFactory = httpClientFactory;
        //    _httpContextAccessor = httpContextAccessor;
        //}


        public async Task<IEnumerable<Movie>> GetMovies()
        {
            var movieList = new List<Movie>();
            movieList.Add(
                new Movie
                {
                    Id = 1,
                    Genre = "Thriller",
                    Title = "Chernobyl",
                    Rating = "9.5",
                    ImageUrl = "image/src",
                    ReleaseDate = DateTime.Now,
                    Owner = "HBO"
                }
                );
            return movieList;
        }
        public Task<Movie> CreateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task<Movie> GetMovie(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}

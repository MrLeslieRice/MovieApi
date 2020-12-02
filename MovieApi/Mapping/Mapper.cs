using System.Diagnostics.CodeAnalysis;
using MovieApi.Factory.Interface;
using MovieApi.Mapping.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieApi.DAL.Models;
using MovieApi.Models;

namespace MovieApi.Mapping
{
    [ExcludeFromCodeCoverage]
    public class Mapper : IMapper
    {
        public void Map(List<MovieModel> movieModels, List<Movie> movies,
            [FromServices] IObjFactory objFactory)
        {
                foreach (var movie in movies)
                {
                    var movieModel = objFactory.CreateMovieModel();

                    movieModel.Title = movie.Title;
                    movieModel.Plot = movie.Plot;
                    movieModel.ReleaseDate = movie.ReleaseDate;
                    movieModel.Duration = movie.Duration;
                    movieModel.MpaaRating = movie.MpaaRating;
                    movieModel.ReleaseYear = movie.ReleaseYear;

                    movieModels.Add(movieModel);
                }
        }

        public void Map(MovieModel movieModel, Movie movie)
        {
            movieModel.Title = movie.Title;
            movieModel.Plot = movie.Plot;
            movieModel.ReleaseDate = movie.ReleaseDate;
            movieModel.Duration = movie.Duration;
            movieModel.MpaaRating = movie.MpaaRating;
            movieModel.ReleaseYear = movie.ReleaseYear;
        }

        public void Map(Movie movie, MovieModel movieModel)
        {
            movie.Title = movieModel.Title;
            movie.Plot = movieModel.Plot;
            movie.ReleaseDate = movieModel.ReleaseDate;
            movie.Duration = movieModel.Duration;
            movie.MpaaRating = movieModel.MpaaRating;
            movie.ReleaseYear = movieModel.ReleaseYear;
        }
    }
}

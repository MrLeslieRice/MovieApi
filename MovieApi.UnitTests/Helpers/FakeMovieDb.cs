using System.Collections.Generic;
using MovieApi.DAL.Models;
using MovieApi.Models;
using System;

namespace MovieApi.UnitTests.Helpers
{
    public static class FakeMovieDb
    {
        public static List<Movie> ReturnMovies()
        {
            return new List<Movie>
            {
                new Movie { Id=1, Title="Fight Club", Plot="Man starts underground fight club.", ReleaseDate = new DateTime(1999,10,12), Duration="139 min", MpaaRating="R", ReleaseYear=1999 },
                new Movie { Id=2, Title="Indiana Jones", Plot="An adventure through a cave.", ReleaseDate = new DateTime(1981,07,16), Duration="152 min", MpaaRating="PG-13", ReleaseYear=1981 },
                new Movie { Id=3, Title="Jurrasic Park", Plot="Scientists bring dinosaurs back to life.", ReleaseDate = new DateTime(1992,04,21), Duration="126 min", MpaaRating="PG-13", ReleaseYear=1992 }
            };
        }

        public static List<MovieModel> ReturnMovieModels()
        {
            return new List<MovieModel>
            {
                new MovieModel { Title="Fight Club", Plot="Man starts underground fight club.", ReleaseDate = new DateTime(1999,10,12), Duration="139 min", MpaaRating="R", ReleaseYear=1999 },
                new MovieModel { Title="Indiana Jones", Plot="An adventure through a cave.", ReleaseDate = new DateTime(1981,07,16), Duration="152 min", MpaaRating="PG-13", ReleaseYear=1981 },
                new MovieModel { Title="Jurrasic Park", Plot="Scientists bring dinosaurs back to life.", ReleaseDate = new DateTime(1992,04,21), Duration="126 min", MpaaRating="PG-13", ReleaseYear=1992 }
            };
        }

        public static Movie ReturnMovie()
        {
            return new Movie { Id = 1, Title = "Fight Club", Plot = "Man starts underground fight club.", ReleaseDate = new DateTime(1999, 10, 12), Duration = "139 min", MpaaRating = "R", ReleaseYear = 1999 };
        }

        public static Movie ReturnDiffMovie()
        {
            return new Movie { Id = 1, Title = "The Hangover", Plot = "A blacked-out night in Las Vegas turns into a search party for a missing friend.", ReleaseDate = new DateTime(2009, 06, 05), Duration = "100 min", MpaaRating = "R", ReleaseYear = 2009 };
        }

        public static List<MovieModel> ReturnMovieModel()
        {
            return new List<MovieModel>()
            {
                new MovieModel { Title = "Fight Club", Plot = "Man starts underground fight club.", ReleaseDate = new DateTime(1999, 10, 12), Duration = "139 min", MpaaRating = "R", ReleaseYear = 1999 }
            };
        }
    }
}

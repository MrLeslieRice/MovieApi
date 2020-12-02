using MovieApi.Repository.Interface;
using System.Collections.Generic;
using MovieApi.DAL.Models;
using System.Linq;

namespace MovieApi.Repository
{
    public class MovieRepo : IMovieRepo
    {
        private IMovieDbContext _movieDb;

        public MovieRepo(IMovieDbContext movieDb)
        {
            _movieDb = movieDb;
        }

        public List<Movie> GetAll() => _movieDb.Movies.ToList();

        public Movie GetMovieById(int id)
            => _movieDb.Movies.FirstOrDefault(m => m.Id == id);

        public bool CreateAMovie(Movie movie)
        {
            _movieDb.Movies.Add(movie);
            var result = _movieDb.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool UpdateAMovie(Movie movie)
        {
            _movieDb.SetModified(movie);
            var result = _movieDb.SaveChanges();
            return result > 0 ? true : false;
        }

        public bool DeleteAMovie(Movie movie)
        {
            _movieDb.Movies.Remove(movie);
            var result = _movieDb.SaveChanges();
            return result > 0 ? true : false;
        }

        public int GetLastMovieId()
        {
            var movies = GetAll();
            return movies.LastOrDefault().Id;
        }

        public bool MovieExists(Movie movie)
        {
            var returnedMovie = _movieDb.Movies
                .FirstOrDefault(m => m.Title == movie.Title
                && m.ReleaseDate == movie.ReleaseDate
                && m.ReleaseYear == movie.ReleaseYear);

            return returnedMovie != null ? true : false;
        }
    }
}

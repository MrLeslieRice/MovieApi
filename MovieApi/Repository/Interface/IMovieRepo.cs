using System.Collections.Generic;
using MovieApi.DAL.Models;

namespace MovieApi.Repository.Interface
{
    public interface IMovieRepo
    {
        List<Movie> GetAll();
        Movie GetMovieById(int id);
        bool CreateAMovie(Movie movie);
        bool UpdateAMovie(Movie movie);
        bool DeleteAMovie(Movie movie);
        int GetLastMovieId();
        bool MovieExists(Movie movie);
    }
}

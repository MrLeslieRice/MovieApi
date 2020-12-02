using System.Collections.Generic;
using MovieApi.DAL.Models;
using MovieApi.Models;

namespace MovieApi.Factory.Interface
{
    public interface IObjFactory
    {
        List<MovieModel> CreateMovieModelList();
        MovieModel CreateMovieModel();
        MovieApiResponse CreateResponse();
        Movie CreateMovie();
    }
}

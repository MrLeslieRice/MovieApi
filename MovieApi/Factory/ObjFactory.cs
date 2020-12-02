using System.Diagnostics.CodeAnalysis;
using MovieApi.Factory.Interface;
using System.Collections.Generic;
using MovieApi.DAL.Models;
using MovieApi.Models;

namespace MovieApi.Factory
{
    [ExcludeFromCodeCoverage]
    public class ObjFactory : IObjFactory
    {
        public List<MovieModel> CreateMovieModelList()
        {
            return new List<MovieModel>();
        }

        public MovieModel CreateMovieModel()
        {
            return new MovieModel();
        }

        public MovieApiResponse CreateResponse()
        {
            return new MovieApiResponse()
            {
                Movies = new List<MovieModel>()
            };
        }

        public Movie CreateMovie()
        {
            return new Movie();
        }
    }
}

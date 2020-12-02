using System.Collections.Generic;
using MovieApi.DAL.Models;
using MovieApi.Models;

namespace MovieApi.UnitTests.Helpers
{
    public static class FakeObjFactory
    {
        public static MovieApiResponse CreateResponse()
        {
            return new MovieApiResponse()
            {
                Movies = new List<MovieModel>()
            };
        }

        public static MovieModel CreateMovieModel()
        {
            return new MovieModel();
        }

        public static Movie CreateMovie()
        {
            return new Movie();
        }
    }
}

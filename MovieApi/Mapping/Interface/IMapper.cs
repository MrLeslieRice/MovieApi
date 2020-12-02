using MovieApi.Factory.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieApi.DAL.Models;
using MovieApi.Models;

namespace MovieApi.Mapping.Interface
{
    public interface IMapper
    {
        void Map(List<MovieModel> movieModels, List<Movie> movies,
            [FromServices] IObjFactory of);
        void Map(MovieModel movieModel, Movie movie);
        void Map(Movie movie, MovieModel movieModel);
    }
}

using static MovieApi.UnitTests.Helpers.FakeMovieDb;
using Microsoft.EntityFrameworkCore;
using MovieApi.DAL.Models;
using MovieApi.Repository;
using NSubstitute;
using System.Linq;

namespace MovieApi.UnitTests.Helpers
{
    public static class Repo
    {
        public static MovieRepo SetupForGetOperations()
        {
            var data = ReturnMovies().AsQueryable();
            var mockSet = Substitute.For<DbSet<Movie>, IQueryable<Movie>>();
            NSubUtils.SetupIQueryable(mockSet, data);
            var mockContext = Substitute.For<IMovieDbContext>();
            mockContext.Movies.Returns(mockSet);
            return new MovieRepo(mockContext);
        }

        public static MovieRepo HappyPathSetupForWriteOperations()
        {
            var mockContext = Substitute.For<IMovieDbContext>();
            mockContext.SaveChanges().Returns(1);
            return new MovieRepo(mockContext);
        }

        public static MovieRepo SadPathSetupForWriteOperations()
        {
            var mockContext = Substitute.For<IMovieDbContext>();
            mockContext.SaveChanges().Returns(0);
            return new MovieRepo(mockContext);
        }
    }
}

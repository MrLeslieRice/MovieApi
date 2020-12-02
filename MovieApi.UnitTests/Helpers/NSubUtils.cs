using Microsoft.EntityFrameworkCore;
using MovieApi.DAL.Models;
using NSubstitute;
using System.Linq;

namespace MovieApi.UnitTests.Helpers
{
    public static class NSubUtils
    {
        public static void SetupIQueryable(DbSet<Movie> mockSet, IQueryable<Movie> data)
        {
            ((IQueryable<Movie>)mockSet).Provider.Returns(data.Provider);
            ((IQueryable<Movie>)mockSet).Expression.Returns(data.Expression);
            ((IQueryable<Movie>)mockSet).ElementType.Returns(data.ElementType);
            ((IQueryable<Movie>)mockSet).GetEnumerator().Returns(data.GetEnumerator());
        }
    }
}

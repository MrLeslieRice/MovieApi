using Microsoft.EntityFrameworkCore;
using System;

namespace MovieApi.DAL.Models
{
    public interface IMovieDbContext : IDisposable
    {
        DbSet<Movie> Movies { get; set; }
        int SaveChanges();
        void SetModified(object entity);
    }
}
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;

namespace MovieApi.Models
{
    [ExcludeFromCodeCoverage]
    public class MovieApiResponse
    {
        public string Info { get; set; }
        public List<MovieModel> Movies { get; set; }
    }
}

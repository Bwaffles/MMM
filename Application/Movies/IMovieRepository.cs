using Domain;
using System.Collections.Generic;

namespace Application.Movies
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> FindAllByUser(int userId);
    }
}
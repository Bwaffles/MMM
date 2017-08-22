using Application.Movies;
using Domain;
using Persistance.Repositories;

namespace Persistance
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository() : base("Movie") { }
    }
}

using Application.Movies;
using Domain;
using Persistance.Repositories;

namespace Persistance
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository() : base("Movie") { }

        public override Movie FindByID(int id)
        {
            var movie = base.FindByID(id);

            var genreRepository = new GenreRepository();
            movie.Genres = genreRepository.FindByMovieId(id);

            return movie;
        }
    }
}

using Application.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Application.Movies.Queries.GetMoviesList
{
    public class GetMoviesListQuery : IGetMoviesListQuery
    {
        IMovieRepository movieRepository;

        public GetMoviesListQuery(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public IEnumerable<MoviesListItemModel> Execute()
        {
            return movieRepository.FindAll().Select(movie =>
                new MoviesListItemModel()
                {
                    Id = movie.Id,
                    Tagline = movie.Tagline,
                    Title = $"{movie.Title} ({movie.ReleaseDate?.Year})",
                });
        }
    }
}

using Domain;
using Mapster;
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
            TypeAdapterConfig<Movie, MoviesListItemModel>
                .NewConfig()
                .Map(dest => dest.Title,
                     src => string.Format("{0} ({1})", src.Title, (src.ReleaseDate.HasValue ? src.ReleaseDate.Value.Year.ToString() : string.Empty)));

            return movieRepository.FindAll().AsQueryable().ProjectToType<MoviesListItemModel>();
        }
    }
}

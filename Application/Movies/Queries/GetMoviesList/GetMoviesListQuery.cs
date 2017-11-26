using Domain;
using Mapster;
using Services.TMDb;
using System.Collections.Generic;
using System.Linq;

namespace Application.Movies.Queries.GetMoviesList
{
    public class GetMoviesListQuery : IGetMoviesListQuery
    {
        private IMovieRepository movieRepository;
        private ITMDbService tmdbService;

        public GetMoviesListQuery(IMovieRepository movieRepository, ITMDbService tmdbService)
        {
            this.movieRepository = movieRepository;
            this.tmdbService = tmdbService;
        }

        public IEnumerable<MoviesListItemModel> Execute()
        {
            TypeAdapterConfig<Movie, MoviesListItemModel>
                .NewConfig()
                .Map(dest => dest.Title,
                     src => string.Format("{0} ({1})", src.Title, (src.ReleaseDate.HasValue ? src.ReleaseDate.Value.Year.ToString() : string.Empty)))
                .Map(dest => dest.PosterUrl, src => tmdbService.GetImagePath(PosterSize.Smallest, src.PosterPath));

            return movieRepository.FindAll().AsQueryable().ProjectToType<MoviesListItemModel>();
        }
    }
}
using System.Collections.Generic;

namespace Application.Movies.Queries.GetMoviesList
{
    public interface IGetMoviesListQuery
    {
        IEnumerable<MoviesListItemModel> Execute(int? userId);
    }
}

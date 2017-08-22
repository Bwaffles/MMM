using Application.Movies.Queries.GetMovieDetails;
using Application.Movies.Queries.GetMoviesList;
using System.Web.Mvc;

namespace Presentation.Movie
{
    public class MoviesController : Controller
    {
        IGetMoviesListQuery moviesListQuery;
        IGetMovieDetailsQuery movieDetailsQuery;

        public MoviesController(IGetMoviesListQuery moviesListQuery, IGetMovieDetailsQuery movieDetailsQuery)
        {
            this.moviesListQuery = moviesListQuery;
            this.movieDetailsQuery = movieDetailsQuery;
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View(moviesListQuery.Execute());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View(movieDetailsQuery.Execute(id));
        }
    }
}

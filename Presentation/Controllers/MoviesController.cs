using Application.Movies.Queries.GetMovieDetails;
using Application.Movies.Queries.GetMoviesList;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class MoviesController : Controller
    {
        private IGetMovieDetailsQuery movieDetailsQuery;
        private IGetMoviesListQuery moviesListQuery;

        public MoviesController(IGetMoviesListQuery moviesListQuery, IGetMovieDetailsQuery movieDetailsQuery)
        {
            this.moviesListQuery = moviesListQuery;
            this.movieDetailsQuery = movieDetailsQuery;
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View(movieDetailsQuery.Execute(id));
        }

        // GET: Movies
        public ActionResult Index()
        {
            return View(moviesListQuery.Execute());
        }
    }
}
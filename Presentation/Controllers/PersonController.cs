using Application.People.Queries.GetPeopleList;
using System.Web.Mvc;

namespace MMM.Presentation.Controllers
{
    public class PersonController : Controller
    {
        private IGetPeopleListQuery peopleListQuery;

        public PersonController(IGetPeopleListQuery peopleListQuery)
        {
            this.peopleListQuery = peopleListQuery;
        }

        // GET: Person
        public ActionResult Index()
        {
            return View(peopleListQuery.Execute());
        }
    }
}
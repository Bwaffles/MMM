using Application.People;
using Domain;

namespace Persistance.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository() : base("Person")
        {
        }
    }
}
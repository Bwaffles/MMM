using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.People.Queries.GetPeopleList
{
    public class GetPeopleListQuery : IGetPeopleListQuery
    {
        private IPersonRepository personRepository;

        public GetPeopleListQuery(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public IEnumerable<PeopleListItemModel> Execute()
        {
            return personRepository.FindAll().AsQueryable().ProjectToType<PeopleListItemModel>();
        }
    }
}
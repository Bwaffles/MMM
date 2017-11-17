using System.Collections.Generic;

namespace Application.People.Queries.GetPeopleList
{
    public interface IGetPeopleListQuery
    {
        IEnumerable<PeopleListItemModel> Execute();
    }
}
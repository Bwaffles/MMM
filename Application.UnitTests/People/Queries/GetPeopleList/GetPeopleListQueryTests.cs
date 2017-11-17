using Application.People;
using Application.People.Queries.GetPeopleList;
using Domain;
using Domain.UnitTests;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Application.UnitTests.People.Queries.GetPeopleList
{
    [TestClass]
    public class GetPeopleListQueryTests
    {
        private Mock<IPersonRepository> Repository;
        private GetPeopleListQuery Target;
        private TestPerson TestPerson;

        [TestInitialize]
        public void BeforeEachTest()
        {
            TestPerson = new TestPerson();

            Repository = new Mock<IPersonRepository>();
            SetupPersonsReturned(new List<Person> { TestPerson.Person });

            Target = new GetPeopleListQuery(Repository.Object);
        }

        [TestMethod]
        public void NoPersonExists_ReturnsEmptyEnumerable()
        {
            SetupPersonsReturned(new List<Person>());
            Execute().Should().BeEmpty();
        }

        [TestMethod]
        public void PersonExists_ReturnsPopulatedItem()
        {
            Execute().First().Name.Should().Be(TestPerson.Name);
        }

        private IEnumerable<PeopleListItemModel> Execute()
        {
            return Target.Execute();
        }

        private void SetupPersonsReturned(List<Person> persons)
        {
            Repository.Setup(repo => repo.FindAll()).Returns(persons);
        }
    }
}
using Application.People.Queries.GetPeopleList;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.UnitTests.People.Queries.GetPeopleList
{
    [TestClass]
    public class PeopleListItemModelTests
    {
        private const int Id = 1;
        private const string Name = "Tony Guy";
        private PeopleListItemModel Target;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new PeopleListItemModel();
        }

        [TestMethod]
        public void GetAndSetId()
        {
            Target.Id = Id;
            Target.Id.Should().Be(Id);
        }

        [TestMethod]
        public void GetAndSetName()
        {
            Target.Name = Name;
            Target.Name.Should().Be(Name);
        }
    }
}
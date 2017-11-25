using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.UnitTests
{
    [TestClass]
    public class PersonTests
    {
        private TestPerson Target;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new TestPerson();
        }

        [TestMethod]
        public void GetAndSetBiography()
        {
            Target.Person.Biography = TestPerson.Biography;
            Target.Person.Biography.Should().Be(TestPerson.Biography);
        }

        [TestMethod]
        public void GetAndSetBirthday()
        {
            Target.Person.Birthday = TestPerson.Birthday;
            Target.Person.Birthday.Should().Be(TestPerson.Birthday);
        }

        [TestMethod]
        public void GetAndSetBirthPlace()
        {
            Target.Person.BirthPlace = TestPerson.BirthPlace;
            Target.Person.BirthPlace.Should().Be(TestPerson.BirthPlace);
        }

        [TestMethod]
        public void GetAndSetDeathday()
        {
            Target.Person.Deathday = TestPerson.Deathday;
            Target.Person.Deathday.Should().Be(TestPerson.Deathday);
        }

        [TestMethod]
        public void GetAndSetGender()
        {
            Target.Person.Gender = TestPerson.Gender;
            Target.Person.Gender.Should().Be(TestPerson.Gender);
        }

        [TestMethod]
        public void GetAndSetHomepage()
        {
            Target.Person.Homepage = TestPerson.Homepage;
            Target.Person.Homepage.Should().Be(TestPerson.Homepage);
        }

        [TestMethod]
        public void GetAndSetId()
        {
            Target.Person.Id = TestPerson.Id;
            Target.Person.Id.Should().Be(TestPerson.Id);
        }

        [TestMethod]
        public void GetAndSetImdbId()
        {
            Target.Person.ImdbId = TestPerson.ImdbId;
            Target.Person.ImdbId.Should().Be(TestPerson.ImdbId);
        }

        [TestMethod]
        public void GetAndSetName()
        {
            Target.Person.Name = TestPerson.Name;
            Target.Person.Name.Should().Be(TestPerson.Name);
        }

        [TestMethod]
        public void GetAndSetPopularity()
        {
            Target.Person.Popularity = TestPerson.Popularity;
            Target.Person.Popularity.Should().Be(TestPerson.Popularity);
        }

        [TestMethod]
        public void GetAndSetProfilePath()
        {
            Target.Person.ProfilePath = TestPerson.ProfilePath;
            Target.Person.ProfilePath.Should().Be(TestPerson.ProfilePath);
        }

        [TestMethod]
        public void GetAndSetTMDBId()
        {
            Target.Person.TMDBId = TestPerson.TMDBId;
            Target.Person.TMDBId.Should().Be(TestPerson.TMDBId);
        }
    }
}
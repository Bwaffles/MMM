using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.UnitTests
{
    [TestClass]
    public class MovieLanguageTests
    {
        private readonly string Name = "English";
        private readonly bool OriginalLanguage = true;

        private MovieLanguage Target;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new MovieLanguage();
        }

        [TestMethod]
        public void CodeNotSet_NameShouldReturnEmptyString()
        {
            Target.Name.Should().BeEmpty();
        }

        [TestMethod]
        public void SetAndGetOriginalLanguage()
        {
            Target.OriginalLanguage = OriginalLanguage;
            Target.OriginalLanguage.Should().Be(OriginalLanguage);
        }

        [TestMethod]
        public void SetCode_NameShouldReturnCountryNameForThatCode()
        {
            Target.Code = "en";
            Target.Name.Should().Be(Name);
        }
    }
}
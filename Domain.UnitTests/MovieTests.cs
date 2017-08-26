using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Domain.UnitTests
{
    [TestClass]
    public class MovieTests
    {
        private readonly IEnumerable<Country> ProductionCountries = new List<Country>() { new Country() { Id = 1, Code = "US" } };

        Movie Target;

        [TestInitialize]
        public void BeforeEachTest()
        {
            Target = new Movie();
        }

        [TestMethod]
        public void SetAndGetProductionCountries()
        {
            Target.ProductionCountries = ProductionCountries;
            Target.ProductionCountries.Should().BeSameAs(ProductionCountries);
        }
    }
}

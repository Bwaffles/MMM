using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistance;

namespace PersistanceTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = new TestDAL();
            var movie = t.GetMovie();
        }
    }
}

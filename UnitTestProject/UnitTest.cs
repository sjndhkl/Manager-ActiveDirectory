using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Manager_ActiveDirectory;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestUTRuns()
        {
            Assert.IsTrue(true);
        }
        [TestMethod]
        public void TestNewEnterprise()
        {
            try
            {
                Enterprise ent = new Enterprise();
                Assert.IsTrue(true);
            }
            catch (Exception)
            {
                Assert.Fail();
                throw;
            }
        }
    }
}

using System;
using Manager_ActiveDirectory;
using NUnit.Framework;

namespace UnitTestProject
{
    [TestFixture]
    public class UnitTest
    {
        [Test]
        public void TestUTRuns()
        {
            Assert.IsTrue(true);
        }
        [Test]
        public void TestNewEnterprise()
        {
            try
            {
                Enterprise ent = new Enterprise();
                Assert.IsTrue(true);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                Assert.Fail();
                throw;
            }
        }
    }
}

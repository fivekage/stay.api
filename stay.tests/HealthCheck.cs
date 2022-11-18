using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace stay.tests
{
    [TestClass]
    public class HealthCheck
    {
        [TestMethod]
        public void TestEverythingOK()
        {
            Assert.IsTrue(1 == 1);
        }
    }
}
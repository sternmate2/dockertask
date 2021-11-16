using BootcampTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootcapProjectTests
{
    [TestClass]
    public class UnitTest1
    {
        readonly TestsConfiguration _tc = new TestsConfiguration();

        [TestMethod]
        public void Test1()
        {
            int x = 7;
            Assert.AreEqual(x, 7);
        }

        [TestMethod]
        public void Test2()
        {
            Assert.AreEqual(1, _tc.GetTestResults() ? 7 : 1);
        }
    }
}

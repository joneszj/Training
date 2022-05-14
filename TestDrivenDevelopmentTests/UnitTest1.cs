using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDevelopment;

namespace TestDrivenDevelopmentTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Assemble
            int i = 1;
            int y = 1;

            // Act
            var result = Program.TestAdd(i, y);

            // Assert
            Assert.IsTrue(result == 2);
        }
    }
}

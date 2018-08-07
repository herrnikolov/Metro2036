using Metro2036.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Metro2036.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //--Arrange
            var options = new DbContextOptionsBuilder<Metro2036DbContext>()
                .UseInMemoryDatabase("Metro2036_Test")
                .Options;

            var context = new Metro2036DbContext(options);

            //--Act

            //--Assert
            //Assert.AreEqual(expected, actual);
        }
    }
}

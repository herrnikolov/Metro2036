using Metro2036.Data;
using Metro2036.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

            context.Routes.Add(new Route() {
                Id = 1,
                RouteId = 838,
                Type = 1,
                RouteName = "Автобаза Искър - Гурко(9)",
                LineId = 2,
                ExtId = 7333,
                LineName = 9
                });
            context.SaveChanges();

            var route = context.Routes.ToList();

            //--Act

            //--Assert
            //Assert.AreEqual(expected, actual);
        }
    }
}

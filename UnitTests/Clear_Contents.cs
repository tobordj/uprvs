using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uh365898_db.Domain.Entities;
using System.Linq;
namespace uh365898_db.UnitTests
{
    //Мы хотим гарантировать, что содержимое корзины удаляется, когда мы ее очищаем.
    namespace UnitTests
    {
        [TestClass]
        public class UnitTest2
        {
            [TestMethod]
            public void Can_Clear_Contents()
            {
                // Arrange - create some test products
                Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
                Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

                // Arrange - create a new cart
                Cart target = new Cart();

                // Arrange - add some items
                target.AddItem(p1, 1);
                target.AddItem(p2, 1);

                // Act - reset the cart
                target.Clear();

                // Assert
                Assert.AreEqual(target.Lines.Count(), 0);
            }
        }
    }
}

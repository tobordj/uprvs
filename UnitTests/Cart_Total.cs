using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uh365898_db.Domain.Entities;
using System.Linq;
namespace uh365898_db.UnitTests

    // Это расчет общей стоимости товаров в корзине

{
    [TestClass]
    public class Cart_Total
    {
        [TestMethod]
public void Calculate_Cart_Total()
{
  // Arrange - create some test products
  Product p0 = new Product { ProductID = 0, Name = "P0", Price = 0M };
  Product p1 = new Product { ProductID = 1, Name = "P1", Price = 100M };
  Product p2 = new Product { ProductID = 2, Name = "P2", Price = 50M };

  // Arrange - create a new cart
  Cart target = new Cart();

  // Act
  target.AddItem(p0, 0);
  target.AddItem(p1, 1);
  target.AddItem(p2, 1);
  target.AddItem(p1, 3);
  decimal result = target.ComputeTotalValue();

  // Assert
  Assert.AreEqual(result, 450M);

    }
    }
}

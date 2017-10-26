using Microsoft.VisualStudio.TestTools.UnitTesting;
using uh365898_db.Domain.Entities;
using System;
using System.Linq;
namespace uh365898_db.UnitTests
{

    [TestClass]
    public class Cart_Line

    {
[TestMethod]
public void Can_Add_Quantity_For_Existing_Lines()
{
  // Arrange - create some test products
  Product p1 = new Product { ProductID = 1, Name = "P1" };
  Product p2 = new Product { ProductID = 2, Name = "P2" };

  // Arrange - create a new cart
  Cart target = new Cart();
  // Act
  target.AddItem(p1, 1);
  target.AddItem(p2, 1);
  target.AddItem(p1, 10);
  CartLine[] results = target.Lines.OrderBy(c => c.Product.ProductID).ToArray();

  // Assert
  Assert.AreEqual(results.Length, 2);
  Assert.AreEqual(results[0].Quantity, 11);
  Assert.AreEqual(results[1].Quantity, 1);
}
}
}

//Однако, если Product уже есть в корзине, мы хотим увеличить количество в соответствующем объекте CartLine и не создавать новый. 
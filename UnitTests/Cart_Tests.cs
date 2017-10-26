using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uh365898_db.Domain.Entities;
using System.Linq;
using uh365898_db.WebUI.Models;
namespace uh365898_db.UnitTests
//Первая линия поведения относится к добавлению элемента в корзину. 
//Если данный объект Product добавляется в корзину в первый раз, то мы хотим,
//чтобы был добавлен новый объект CartLine. 
{

  [TestClass]
  public class Cart_Tests
  {

   [TestMethod]
    public void Can_Add_New_Lines()
    {
      // Arrange - create some test products
      Product p1 = new Product { ProductID = 1, Name = "P1" };
      Product p2 = new Product { ProductID = 2, Name = "P2" };

      // Arrange - create a new cart
      Cart target = new Cart();
      // Act
      target.AddItem(p1, 1);
      target.AddItem(p2, 1);
      CartLine[] results = target.Lines.ToArray();

      // Assert
      Assert.AreEqual(results.Length, 2);
      Assert.AreEqual(results[0].Product, p1);
      Assert.AreEqual(results[1].Product, p2);

        }
    }
}

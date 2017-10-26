using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uh365898_db.Domain.Abstract;
using Moq;
using uh365898_db.Domain.Entities;
using uh365898_db.WebUI.Controllers;
using System.Web.Mvc;
namespace UnitTests
{
    [TestClass]
    public class Checkout_And_Submit_Order
    {
        [TestMethod]
        public void Can_Checkout_And_Submit_Order()
        {
            // Arrange - create a mock order processor
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            // Arrange - create a cart with an item
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);

            Order order = new Order();
            Shipping shipping = new Shipping();

              // Arrange - create an instance of the controller
            CartController target = new CartController(null, mock.Object);

            // Act - try to checkout
            ViewResult result = target.Checkout(new Order(), new Shipping(), cart);

            // Assert - check that the order has been passed on to the processor
            mock.Verify(m =>
              m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<Shipping>()), Times.Once());

            // Assert - check that the method is returning the Completed view
            Assert.AreEqual("Completed", result.ViewName);
            Assert.AreEqual("Checkout", result.ViewName);
            // Assert - check that we are passing a valid model to the view
            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);

        }
    }
}
//Установив, что заказ не будет обрабатываться при пустой корзине или недействительных
//реквизитах, мы должны гарантировать, что обрабатываем заказы должным образом. 

//Обратите внимание, что не нужно проверить, можем ли мы определить действительность
//реквизитов доставки. Это выполняется автоматически механизмом связывания с помощью атрибутов, 
//которые мы применили к свойствам класса ShippingDetails.

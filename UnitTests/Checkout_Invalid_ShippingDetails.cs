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
    public class Checkout_Invalid_ShippingDetails
    {
        [TestMethod]
        public void Cannot_Checkout_Invalid_ShippingDetails()
        {
            // Arrange - create a mock order processor
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
             Mock<IProductRepository> mock1 = new Mock<IProductRepository>();
            // Arrange - create a cart with an item
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            Order order = new Order();
            Shipping shipping = new Shipping();
            // Arrange - create an instance of the controller
            CartController target = new CartController(null, mock.Object);
            ControlsystemController adm = new ControlsystemController(mock1.Object);
            // Arrange - add an error to the model
            target.ModelState.AddModelError("error", "error");

            // Act - try to checkout
            ViewResult result = target.Checkout(order, new Shipping(), cart);

            ViewResult adresul = adm.Shippord();
            // Assert - check that the order hasn't been passed on to the processor
            mock.Verify(m =>
              m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<Shipping>()), Times.Never());

            // Assert - check that the method is returning the default view
            Assert.AreEqual("", adresul.ViewName);
            Assert.IsNotNull(adresul);
            //
            Assert.AreEqual(false, adresul.ViewData.ModelState.IsValid);
            // Assert - check that we are passing an invalid model to the view
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }
    }
}
//метод работает во многом таким же образом, но он внедряет сообщение об 
//ошибке в модель представления и поручает механизму связывания данных сообщить
//об ошибке (что произойдет, когда клиент введет недействительные реквизиты доставки):
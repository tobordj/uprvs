using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using uh365898_db.Domain.Abstract;
using uh365898_db.Domain.Entities;
using uh365898_db.WebUI.Controllers;
using System;
using System.Linq;
using System.Web.Mvc;
namespace uh365898_db.UnitTests
{
    [TestClass]
    public class CheckoutEmptyCart
    {
        [TestMethod]
        public void Cannot_Checkout_Empty_Cart()
        {
            // Arrange - create a mock order processor
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();

            // Arrange - create an empty cart
            Cart cart = new Cart();

            // Arrange - create shipping details
            Shipping shipping = new Shipping();
            // Arrange - create shipping details
            Order order = new Order();

            // Arrange - create an instance of the controller
            CartController target = new CartController(null, mock.Object);

            // Act
            ViewResult result = target.Checkout(order, shipping, cart);

            // Assert - check that the order hasn't been passed on to the processor
            mock.Verify(m =>
              m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<Shipping>()), Times.Never());

            // Assert - check that the method is returning the default view
            Assert.AreEqual("", result.ViewName);

            // Assert - check that we are passing an invalid model to the view
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);
        }
    }
}
//Этот тест гарантирует, что пользователь не сможет подтвердить покупку с пустой корзиной. 
//Чтобы это проверить, мы утверждаем, что ProcessOrder имитированной реализации IOrderProcessor никогда не вызывается,
//что метод возвращает представление по умолчанию (которое снова отобразит данные, введенные пользователем,
//и даст возможность их исправить), и что состояние модели, которое передается в представление, отмечено как недопустимое.
//Может показаться, что наши утверждения дублируют друг друга, но нам нужны все три, чтобы гарантировать корректное поведение.
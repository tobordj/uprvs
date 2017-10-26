using Microsoft.VisualStudio.TestTools.UnitTesting;
using uh365898_db.Domain.Abstract;
using Moq;
using uh365898_db.Domain.Entities;
using uh365898_db.WebUI.Controllers;
using System.Web.Mvc;
namespace uh365898_db.UnitTests
{
    [TestClass]
    public class Checkout_And_Submit_Order
    {

        [TestMethod]
        public void Can_Save_Valid_Changes()
    {
          // Arrange - create mock repository
          Mock<IProductRepository> mock = new Mock<IProductRepository>();
          // Arrange - create the controller
          ControlsystemController target = new ControlsystemController(mock.Object);
          // Arrange - create a product
          Product product = new Product { Name = "Test" };
          // Act - try to save the product
          ActionResult result = target.Edit(product);
          // Assert - check that the repository was called
          mock.Verify(m => m.SaveProduct(product));
          // Assert - check the method result type
          Assert.IsNotInstanceOfType(result, typeof(ViewResult));
            }

    [TestMethod]
    public void Cannot_Save_Invalid_Changes()
    {
          // Arrange - create mock repository
          Mock<IProductRepository> mock = new Mock<IProductRepository>();
          // Arrange - create the controller
          ControlsystemController target = new ControlsystemController(mock.Object);
          // Arrange - create a product
          Product product = new Product { Name = "Test" };
          // Arrange - add an error to the model state
          target.ModelState.AddModelError("error", "error");
          // Act - try to save the product
          
          ActionResult result = target.Edit(product, null);
          // Assert - check that the repository was not called
          mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never());
          // Assert - check the method result type
          Assert.IsInstanceOfType(result, typeof(ViewResult));
    }

    [TestMethod]
    public void Can_Save_Shipping_Changes()
    {
        // Arrange - create mock repository
        Mock<IOrderProcessor> moc1 = new Mock<IOrderProcessor>();
         Mock<IProductRepository> moc2 = new Mock<IProductRepository>();
        // Arrange - create the controller
        CartController target = new CartController(moc2.Object, moc1.Object);
        // Arrange - create a 
       Shipping shipping = new Shipping { Name = "Ship" };
       Order order = new Order();
       Cart cart = new Cart();
        // Act - try to save the product
        ActionResult adresult = target.Checkout(order, shipping, cart);
        // Assert - check that the repository was called
        moc2.Verify(m => m.SaveShipping(It.IsAny<Shipping>()), Times.Never());
        // Assert - check the method result type
        Assert.IsNotInstanceOfType(adresult, typeof(ActionResult));
    }



  }
}
//Для обработки запросов POST метода действия Edit мы должны убедиться,
//что для сохранения в хранилище передаются только действительные
//обновления объекта Product, созданного механизмом связывания. 
//Мы также хотим гарантировать, что недействительные обновления, 
//в которых существует ошибка модели, не передаются в хранилище. 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using uh365898_db.Domain.Abstract;
using Moq;
using uh365898_db.Domain.Entities;
using uh365898_db.Domain.Concrete;
using uh365898_db.WebUI.Controllers;
using System.Web.Mvc;
using System.Collections;
using System.Linq;

namespace uh365898_db.UnitTests


{
    [TestClass]
    public class DeleteProductAdmin
    {
        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            // Arrange - create a Product
            Product prod = new Product { ProductID = 2, Name = "Test" };
           
            // Arrange - create the mock repository
           
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                prod,
                new Product {ProductID = 3, Name = "P3"},
              }.AsQueryable());
            
            // Arrange - create the controller

            ControlsystemController target = new ControlsystemController(mock.Object);
            // Act - delete the product
           
            target.Delete(prod.ProductID);
            // Assert - ensure that the repository delete method was
            // called with the correct Product
            
            mock.Verify(m => m.DeleteProduct(prod.ProductID));
        }
    }
}

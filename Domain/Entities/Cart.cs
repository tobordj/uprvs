using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Web.Compilation;
using System.CodeDom;
namespace uh365898_db.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
           {
            CartLine line = lineCollection
              .Where(p => p.Product.ProductID == product.ProductID)
              .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
           }


        public int UpdateQuantity(Product product, int quantity)
        {
           
               CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
              int itemCount = 0;   
            try
            { 
                    
                if (quantity > 0)
                {
                    line.Quantity = Convert.ToInt32(quantity);
                    return itemCount = Convert.ToInt32(line.Quantity);
                }

                if (quantity < 0)
                {
                    line.Quantity = Convert.ToInt32(-quantity);
                    return itemCount = Convert.ToInt32(-line.Quantity);
                }

               // if (quantity == 0)
                //{ return lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID); }
            }

              catch (FormatException)
                {
                    return itemCount = Convert.ToInt32(line.Quantity);
                 }
               
             return itemCount = Convert.ToInt32(line.Quantity);
        }
    
            




        public void RemoveLine(Product product)
          {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
          }

        public decimal ComputeTotalValue()
           {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);
          }

        public void Clear()
           {
            lineCollection.Clear();
            }

        public IEnumerable<CartLine> Lines
           {
            get { return lineCollection; }
           }
    }

    public class CartLine
    {
        public Product Product { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = " ")]
        [RegularExpression("([0-9]+)")] 
        [Range(0, 10, ErrorMessage = "Количество должно быть до 10")]
        public int Quantity { get; set; }
    }
}
//Класс Cart использует CartLine, определенный в том же файле, чтобы представлять товар, 
//выбранный покупателем, и количество данного товара.
//Мы определили методы, которые позволяют добавлять товар в корзину, удалять ранее добавленный товар,
//рассчитать общую стоимость товаров в корзине и очистить корзину, удалив все выбранное.
//Мы также предоставили свойство, которое дает доступ к содержимому корзины с помощью IEnumerble<CartLine>
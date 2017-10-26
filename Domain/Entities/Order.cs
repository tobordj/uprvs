using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace uh365898_db.Domain.Entities
{
     public class Order
    {

    public int  OrderID    { get; set; }
    public DateTime DateAdded { get; set; }
    public int Prodnumb  { get; set; }
    public string Prodname { get; set; }
    public  decimal Total      { get; set; }
    public decimal Price { get; set; }
    public decimal Allprice { get; set; }
    public int? ShippingShippingID { get; set; }
    public Shipping Shipping { get; set; } // Свойство называется навигационным свойством - при получении 
         //данных об заказе оно автоматически будет получать данные из БД. 
        // Однако для этого нам надо также установить внешний ключ.

  
   }
}

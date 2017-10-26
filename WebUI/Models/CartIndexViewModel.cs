using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uh365898_db.Domain.Entities;

namespace uh365898_db.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Product Product { get; set; }
        public Order Order { get; set; }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public string ReturnedUrl { get; set; }
        public int quantity { get; set; } 
    }
}
//Мы реализуем метод Index и будем использовать его для отображения содержимого корзины. 
//Если вы вернетесь к рисунку 8-8, то увидите, это наш рабочий поток после того, как пользователь нажимает кнопку Add to cart.
//Нам нужно передать две порции информации в представление, которое будет отображать содержимое корзины: 
//объект Cart и URL, который будет отображен, если пользователь нажмет кнопку Continue shopping.
//Для этого мы создадим простой класс модели представления. 
//Когда у нас готова модель представления, мы можем реализовать метод действия Index в классе контроллера Cart

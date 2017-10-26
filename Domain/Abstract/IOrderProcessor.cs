using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uh365898_db.Domain.Entities;

namespace uh365898_db.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, Shipping shipping, Order order);
    }
}
// IOrderProcessor будет обрабатывать заказы, отправляя их по электронной почте администратору сайта.
// Конечно, мы упрощаем процесс продажи. Большинство сайтов электронной коммерции не ограничиваются 
// подтверждением заказов по e-mail, к тому же мы не обеспечили поддержку для обработки кредитных карт
//и других форм оплаты. Но мы не хотим отвлекаться от MVC, так что будем работать с электронной почтой.
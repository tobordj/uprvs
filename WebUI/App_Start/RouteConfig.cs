using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace uh365898_db.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
           // routes.IgnoreRoute("Content/{filename}.html"); obxod sistemu marshrutizacii

            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}", new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });
            //



            routes.MapRoute(null,
        "",
        new { controller = "Product", action = "List"}
      );

            routes.MapRoute(null,
 "Каталог/",
 new { controller = "Product", action = "Shop", categzer = (string)null, categ = (string)null, twocateg = (string)null, fabrica = (string)null }
);

            routes.MapRoute(null,
"Производители/",
new { controller = "Product", action = "Shop", categzer = (string)null, categ = (string)null, twocateg = (string)null, fabrica = (string)null }
);

            routes.MapRoute(null,
"Производители/{fabrica}",
new { controller = "Product", action = "Shop", categzer = (string)null, categ = (string)null, twocateg = (string)null,  fabrica = ""}
);

            routes.MapRoute(null,
"Каталог/",
new { controller = "Product", action = "Shop", categzer = (string)null, categ = (string)null, twocateg = (string)null }
);

            

            routes.MapRoute(null,
"Каталог/{categzer}",
new { controller = "Product", action = "Shop", categzer = "", categ = (string)null, twocateg = (string)null });



            routes.MapRoute(null,
"О_нас",
new { controller = "Nav", action = "AboutUs" });

            routes.MapRoute(null,
  "Товар/{ProductID}",
  new { controller = "Product", action = "Store", ProductID = ""});

    routes.MapRoute(null,
  "Контакты",
        new { controller = "Nav", action = "Contacts"});

   routes.MapRoute(null,
   "Вопросы",
   new { controller = "Nav", action = "Question"});

   routes.MapRoute(null,
"Смешивание_пантонов",
new { controller = "Nav", action = "Mixing_Ponton" });

   routes.MapRoute(null,
"Установка_планок_на_резину",
new { controller = "Nav", action = "Planks" });

   routes.MapRoute(null,
"Доставка",
new { controller = "Nav", action = "Delivery"});


   routes.MapRoute(null,
"Сервис",
new { controller = "Nav", action = "Service"});


   routes.MapRoute(null,
"Корзина_заказов/",
new { controller = "Cart", action = "Index"});
   

   routes.MapRoute(null,
"Оформление_заказа/",
new { controller = "Cart", action = "Checkout" });


   routes.MapRoute(null,
"Заказ_принят/",
new { controller = "Cart", action = "Completed" });



             routes.MapRoute(null,
 "Каталог/{categzer}/{categ}",
 new { controller = "Product", action = "Shop", categzer = "", categ = "", twocateg = (string)null });

            routes.MapRoute(null,
"Каталог/{categzer}/{categ}/{*twocateg}",
new { controller = "Product", action = "Shop", categzer = "", categ = "", twocateg =""});

         
            /*      

            


         routes.MapRoute(null,
           "",
           new
           {   controller = "Product",  action = "List",    category = (string)null,    page = 1    }
         );




          
    routes.MapRoute(null,
      "Page{page}",
      new { controller = "Product", action = "List", category = (string)null },
      new { page = @"\d+" }
    );

    routes.MapRoute(null,
      "{category}",
      new { controller = "Product", action = "List", page = 1 }
    );

    routes.MapRoute(null,
      "{category}/Page{page}",
      new { controller = "Product", action = "List" },
      new { page = @"\d+" }
    );



         */



            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute("404-catch-all", "{*catchall}",
      new { controller = "Error", action = "HttpNotFound" });
        }
    }
}
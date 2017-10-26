using uh365898_db.Domain.Abstract;
using uh365898_db.Domain.Entities;
using uh365898_db.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uh365898_db.Domain.Concrete;
using System.Threading.Tasks;
using BotDetect.Web.UI.Mvc;
using System.Net.Mail;
using System.Net;

namespace uh365898_db.WebUI.Controllers
{
    public class CartController : Controller
    {
        private const string sessionKey = "Cart";
        public EFBContext cont = new EFBContext();
        private IProductRepository repository;
        private IOrderProcessor orderProcessor;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CartController(IProductRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }


        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpGet]
        public ViewResult Index(Cart cart, Order order, string returnUrl, string returnedUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl,
                ReturnedUrl = returnedUrl,
                Order = order
            });
        }


        public RedirectToRouteResult UpdQuant(Cart cart, Product product, string returnUrl,  Order order, int quantity)
        {
           
          List<CartLine> lineCollection = new List<CartLine>();
          CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line != null)
            { 
                order.Total= line.Quantity;
              //  cart.UpdateQuantity(product, quantity);
            }
            return RedirectToAction("Index", new { quantity });
        }


        [HttpPost]
        public ActionResult Index(ControllerContext controllerContext, Product product, Cart cart, Order order, int quantity, object sender, EventArgs e)
        {

            if (ModelState.IsValid)
            {
                Cart ourcart = (Cart)controllerContext.HttpContext.Session[sessionKey];

                var cartItems = ourcart.Lines;
                foreach (var item in cartItems)
                {
                    order.Prodnumb = item.Product.ProductID; 
                    order.Total= item.Quantity;
                                     
                 }
                controllerContext.HttpContext.Session[sessionKey] = cartItems; 
            }
                return View("Checkout",  order.Total);
           
        }





        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Не корректный CAPTCHA код")]
        public ViewResult Checkout(Order order, Shipping shipping, Cart cart)
              {
                  logger.Error("Отправка заказа в админку");
                  if (cart.Lines.Count() == 0)
                  {
                      ModelState.AddModelError("", "Извините, но Ваша корзина пуста!");
                  }

                                
                  if (ModelState.IsValid)
                  {

                       var cartItems = cart.Lines;
                       foreach (var item in cartItems)
                       {
                           item.Quantity = item.Quantity;
                           order.Total =item.Quantity;
                       }

                    // orderProcessor.ProcessOrder(cart, shipping, order); // 
                      
                    shipping.ShippingID = shipping.ShippingID;
                    shipping.DateAdded = DateTime.Now;
                    shipping.Name = shipping.Name;
                    shipping.City = shipping.City;
                    shipping.State = shipping.State;
                    shipping.Zip = shipping.Zip;
                    shipping.Address = shipping.Address;
                    shipping.Phone = shipping.Phone;
                    shipping.Email = shipping.Email;
                    shipping.Message = shipping.Message;

                //infouprkh@gmail.com
                 MailAddress fromMailAddress = new MailAddress("infouprkh@gmail.com", "UPR");
                // MailAddress toAddress = new MailAddress("drobotjv@gmail.com", "Tom");
                MailAddress toAddress = new MailAddress("upr_kharkiv@ukr.net", "UPR");
                using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    mailMessage.Subject = "Заказ c сайта upr.kh.ua";


                    mailMessage.Body =  "Имя " + shipping.Name.ToString() + "\r" +
                                        "Город " + shipping.City.ToString() + "\r" +
                                        "Почтовый индекс " + shipping.Zip.ToString() + "\r" +
                                       "Адрес " + shipping.Address.ToString() + "\r" +
                                      "Телефон " + shipping.Phone.ToString() + "\r" +
                                      "Email " + shipping.Email.ToString() + "\r" +
                                      "Время " + DateTime.Now.ToString() + "\r" +
                                      "Cообщение " + shipping.Message.ToString() + "\r";
                    
                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "1234567upr");

                    smtpClient.Send(mailMessage);
                }




                repository.SaveShipping(shipping);
                     repository.SaveOrder(cart,shipping,order);
                     cart.Clear();
                    
                     MvcCaptcha.ResetCaptcha("SampleCaptcha");
                      return View("Completed", shipping);
                  }
                  else
                  {
                      return View(shipping);
                  }
              }
       
      

        public ViewResult Checkout()
              {
                  return View(new Shipping());
                                      }

         [HttpPost]
         
         [HandleError(ExceptionType = typeof(NotImplementedException), View = "Index")]
        public RedirectToRouteResult UpdateCart(Cart cart, int productId, string returnUrl, int quantity,  string returnedUrl)
        {    
        //   List<CartLine> lineCollection = new List<CartLine>();
         //   CartLine line = lineCollection.Where(p => p.Product.ProductID == productId).FirstOrDefault();
             try 
            {
             Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
                {
               
                 //   line.Quantity = quantity;
                 cart.UpdateQuantity(product, quantity);
                 //подготовка сообщения
                 string msg = "Количество" + Server.HtmlEncode(product.Name) +  "изменено в вашей корзне.";
                 if (quantity == 0) msg = Server.HtmlEncode(product.Name) +  " товар был удален из вашей корзны";
                 //
                 // Display the confirmation message 
                

               }
            }
             catch (Exception)
             {
                 return RedirectToAction("Index", new { quantity, returnUrl, returnedUrl, }); 
             }
            return RedirectToAction("Index", new { quantity, returnUrl, returnedUrl });
                       
        }


       
        

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl, int quantity=1)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
           // List<CartLine> lineCollection = new List<CartLine>();
           // CartLine line = lineCollection.Where(p => p.Product.ProductID == productId).FirstOrDefault();
           // line.Quantity = quantity;
          //   int quantity = 1;
            if (product != null)
            {
               
                cart.AddItem(product, quantity);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


        public class Err : HandleErrorAttribute
        {
            public override void OnException(ExceptionContext filterContext)
            {
                Exception ex = filterContext.Exception;
                filterContext.ExceptionHandled = true;
                var model = new HandleErrorInfo(filterContext.Exception, "Cart", "UpdateCart");

                filterContext.Result = new ViewResult()
                {
                    ViewName = "Index",
                    ViewData = new ViewDataDictionary(model)
                };
            }
        }

        protected override void Dispose(bool disposing)
        {
           cont.Dispose();
            base.Dispose(disposing);
        }
        
    }
}
//Первое касается того, что мы используем состояние сессии ASP.NET для сохранения и извлечения объектов Cart. 
//Это задача метода GetCart. В ASP.NET есть объект Session, который использует cookie или перезапись URL для
//группировки запросов от пользователя, чтобы сформировать одну сессию просмотра.
//Состояние сессии (session state) позволяет связывать данные с сессией. Оно идеально подходит для нашего класса Cart. 
//Мы хотим, чтобы у каждого пользователя была своя корзина, и чтобы она сохранялась в промежутках времени между запросами.
// Данные, которые связываются с сессией, удаляются, когда сессия истекает (обычно потому, что пользователь не отправлял 
// запросы некоторое время). Это означает, что мы не должны управлять хранением или жизненным циклом объектов Cart. 
//Чтобы добавить объект в состояние сессии, мы устанавливаем значение для ключа в объекте Session,
//Session["Cart"] = cart;
//Cart cart = (Cart)Session["Cart"];

//Для методов AddToCart и RemoveFromCart мы использовали имена параметров, которые соответствуют элементам input в формах HTML,
//которые мы создали в представлении ProductSummary.cshtml. Это позволяет MVC Framework связывать входящие переменные формы POST
//с этими параметрами, что избавляет нас от необходимости обрабатывать форму самим.

//Последнее замечание по поводу контроллера Cart состоит в том, что и метод AddToCart, и RemoveFromCart вызывают метод 
//RedirectToAction. В результате этого браузеру клиента отправляется HTTP-инструкция перенаправления, которая сообщает
//браузеру запросить новый URL. В этом случае мы сообщаем браузеру запросить URL, который будет вызывать метод действия Index контроллера Cart.

//к методу действия Checkout теперь добавляется атрибут HttpPost, что означает, что он будет вызван для 
//обработки запроса POST (в данном случае, когда пользователь отправляет форму). Опять же, мы полагаемся на механизм 
//связывания данных как для параметра ShippingDetails (который создается автоматически на основе данных формы HTTP), 
//так и для параметра Cart (который создается с помощью нашего пользовательского механизма связывания).

//Метод Summary просто визуализирует представление, предоставляя текущий объект Cart 
        //(который будет получен с помощью нашего пользовательского механизма связывания),
        //в качестве данных представления. Нам нужно создать частичное представление, которое будет
        //отображаться в ответ на вызов метода Summary

//Метод Checkout возвращает представление по умолчанию и передает в него новый объект ShippingDetails как модель представления.
//Чтобы создать соответствующее представление, кликните правой кнопкой мыши метод Checkout
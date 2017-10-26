using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uh365898_db.Domain.Abstract;
using System.Data.Entity;
using uh365898_db.WebUI.Models;
using System.Net.Mail;
using System.Net;
using System.IO;
using uh365898_db.Domain.Entities;
using uh365898_db.Domain.Concrete;
using System.Threading.Tasks;
using Microsoft.CSharp;
using BotDetect.Web.UI.Mvc;





namespace uh365898_db.WebUI.Controllers
{
   // [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]

    public class NavController : Controller
    {
        private IProductRepository repository;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      
        public NavController(IProductRepository repo)
        {
            this.repository = repo;
        }

      
       
        public PartialViewResult Menu() // выбираем по разделу
        {
            IEnumerable<string> categories = repository.Products
              .Select(x => x.Categtw.Name)
              .Distinct()
              .OrderBy(x => x);
            return PartialView(categories);
            

        }


        public ViewResult Contacts()
        {
            logger.Error("Просмотр форма Контакты");
             return View();
         }

        public ActionResult AboutUs(string name = "")
        {
            logger.Error("Просмотр форма Про нас");
            ViewBag.Name = name;
            return View();
        }


        public ViewResult Documents()
        {
            return View();
        }
        public ViewResult Service()
        {
            return View();
        }
        public ViewResult Promotion()
        {
            return View();

        }
        public ViewResult Question()

        {
            logger.Error("Просмотр формы Вопрос технологу");
            return View();

        }

        public ViewResult Payment()// v yclovia pokupki
        {
            return View();

        }

        public ViewResult Delivery()// v yclovia pokupki

        {
            logger.Error("Просмотр формы Доставка");
            return View();

        }

        public ViewResult Mixing_Ponton()// v yclovia pokupki
        {
            return View();

        }

        public ViewResult Planks()// v yclovia pokupki
        {
            return View();

        }
        

          public ViewResult  Partners()
        {
            return View();

        }




          [HttpPost]
          [AllowAnonymous]
          [ValidateAntiForgeryToken]
          [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Не корректный CAPTCHA код")]
        public ActionResult Question(Guestbook guestbookID, string actName)
        {
            logger.Error("Форма вопрос технологу - отправка вопроса");

            if (ModelState.IsValid)
            {
                
                actName = "Вопросы";
                guestbookID.DateAdded = DateTime.Now;
                repository.SaveGuestbook(guestbookID);
                MvcCaptcha.ResetCaptcha("SampleCaptcha");
                TempData["message"] = string.Format("{0}, Ваше сообщение отправлено", guestbookID.Name);

                //infouprkh@gmail.com
                MailAddress fromMailAddress = new MailAddress("infouprkh@gmail.com", "UPR");
                // MailAddress toAddress = new MailAddress("drobotjv@gmail.com", "Tom");
                MailAddress toAddress = new MailAddress("upr_kharkiv@ukr.net", "UPR");
                using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    mailMessage.Subject = "Вопрос технологу c сайта upr.kh.ua";


                    mailMessage.Body = "Тема сообщения: " + guestbookID.Name.ToString() + "\r" +
                                        "Дата: " + guestbookID.DateAdded.ToString() + "\r" +
                                        "Сообщение: " + guestbookID.Message.ToString() + "\r";

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "1234567upr");

                    smtpClient.Send(mailMessage);
                }

                

                return RedirectToAction("Question", guestbookID);

            }
            else
            {
                return View();
            }
        }

        public ActionResult VseOtzuvu()
        {
            var mostRecentEntries =
                (from entry in repository.Guestbooks
                 orderby entry.DateAdded descending
                 select entry).Take(20);
               //    repository.Guestbooks =  mostRecentEntries.ToList();
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [CaptchaValidation("CaptchaCode", "SampleCaptcha", "Не корректный CAPTCHA код")]

        public ActionResult Contacts(Offer offer, HttpPostedFileBase image)
        {
            logger.Error("Oтправка формы Контакт админстратору ");

            if (ModelState.IsValid)
            {
                // TODO: Captcha validation failed, show error message
               
                                      
                if (image != null)
               {
                   offer.ImageMimeType = image.ContentType;
                   offer.ImageData = new byte[image.ContentLength];
                   image.InputStream.Read(offer.ImageData, 0, image.ContentLength);
                  
               }
                offer.DateAdded = DateTime.Now;

                //infouprkh@gmail.com
                MailAddress fromMailAddress = new MailAddress("infouprkh@gmail.com", "UPR");
                MailAddress toAddress = new MailAddress("upr_kharkiv@ukr.net", "UPR");
               // MailAddress toAddress = new MailAddress("drobotjv@gmail.com", "UPR");
                using (MailMessage mailMessage = new MailMessage(fromMailAddress, toAddress))
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    mailMessage.Subject = "Форма обратная связь c сайта upr.kh.ua";


                    mailMessage.Body = "Имя: " + offer.Name.ToString() + "\r"+
                                      "Телефон: " + offer.Phone.ToString() + "\r"+
                                      "Почта: " + offer.Email.ToString() + "\r" +
                                      "Дата: " + offer.DateAdded.ToString() + "\r" +
                                      "Тема сообщения: " + offer.Title.ToString() + "\r" +
                                      "Сообщение: " + offer.Description.ToString() + "\r" ;

                    smtpClient.Host = "smtp.gmail.com";
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromMailAddress.Address, "1234567upr");

                    smtpClient.Send(mailMessage);
                }


                repository.SaveOffer(offer);
                TempData["message"] = string.Format("{0}, Ваше сообщение отправлено", offer.Name);
                MvcCaptcha.ResetCaptcha("SampleCaptcha");

                return RedirectToAction("Contacts");

            }
            else
            {
                return View(offer);
            }
           
                // there is something wrong with the data values
                
            
        }


        public FileContentResult GetFile(int offerId)
        {
            Offer fer = repository.Offers.FirstOrDefault(p => p.OfferID == offerId);
            if (fer != null)
            {
                return File(fer.ImageData, fer.ImageMimeType);
            }
            else
            {
                return null;
            }
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, Categone categone, HttpPostedFileBase image)
        {
            logger.Error("Редактирование товара");
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

       
                
    }
}






//Мы добавили в метод действия Menu параметр под названием category. 
//Значение этого параметра будет предоставлено автоматически конфигурацией маршрутизации.
//В теле метода мы динамически создали свойство SelectedCategory в объекте ViewBag и приравняли 
//его значение к значению параметра category. Как мы уже объясняли в главе 2, ViewBag является динамическим объектом, 
//и мы создаем новые свойства, просто 
using System.Net.Mail;
using System.Text;
using uh365898_db.Domain.Abstract;
using uh365898_db.Domain.Entities;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.IO;
using uh365898_db.Domain.Concrete;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace uh365898_db.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "jdrobot@ukr.net";
        public string MailFromAddress = "info@upr.kh.ua";
        public bool UseSsl = false;
        public string Username = "info@upr.kh.ua";
        public string Password = "7vZ2kSsBcn";
        public string ServerName = "upr.kh.ua";   //smtp.example.com";
        public int ServerPort = 33301;
        public bool WriteAsFile = true; //false;
        public string FileLocation = @"d:\Program\ASP";
    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, Shipping shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder()
                  .AppendLine("Был принят новый заказ")
                  .AppendLine("---")
                  .AppendLine("Список товаров:");

                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    var dt = DateTime.Now;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity, line.Product.Name, subtotal);
                }

                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                  .AppendLine("---")
                  .AppendLine("Ship to:")
                  .AppendLine(shippingInfo.Name)
                  .AppendLine(shippingInfo.Phone)
                  .AppendLine(shippingInfo.State)
                  .AppendLine(shippingInfo.Zip)
                  .AppendLine(shippingInfo.Address)
                  .AppendLine(shippingInfo.Email)
                  .AppendLine(shippingInfo.Message)
                  .AppendLine("---");

                MailMessage mailMessage = new MailMessage(
                  emailSettings.MailFromAddress, // From
                  emailSettings.MailToAddress, // To
                  "Новый заказ был принят!", // Subject
                  body.ToString()); // Body

                if (emailSettings.WriteAsFile)
                {
                   // mailMessage.BodyEncoding = Encoding.ASCII;

                    mailMessage.SubjectEncoding = Encoding.Default;
                    mailMessage.BodyEncoding = Encoding.Default;
                    mailMessage.Headers["Content-type"] = "text/plain; charset=windows-1251";

                    
                }
                try
                {
                    smtpClient.Send(mailMessage);
                }
                catch (SmtpException ex)
                {
                    //В случае ошибки при отсылке сообщения можем увидеть, в чем проблема
                    Console.WriteLine(ex.InnerException.Message.ToString());
                }
            }
        }
    }
}


//Для простоты мы также определили в листинге 9-14 класс EmailSettings.
//Экземпляр этого класса требуется конструктором EmailOrderProcessor и содержит все настройки, которые необходимы для конфигурации классов .NET, работающих с электронной почтой.
//Eсли нет сервера SMTP. Если вы установите свойству EmailSettings.WriteAsFile значение true, e-mail сообщения будут записываться как файлы в директорию,
//указанную в свойстве FileLocation. Эта директория должна существовать и быть доступной для записи. Файлы будут записаны с расширением .eml, но их можно прочитать в любом текстовом редакторе.
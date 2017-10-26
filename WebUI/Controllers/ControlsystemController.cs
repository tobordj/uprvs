using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uh365898_db.Domain.Abstract;
using uh365898_db.Domain.Entities;
using uh365898_db.Domain.Concrete;
using uh365898_db.WebUI.Models;
using System.Data.Entity;
using System.Data;
using System.Data.Sql;
//using System.Web.UI.DataVisualization.Charting;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
//using SimpleChart = System.Web.Helpers;
using System.Collections;
using System.Web.Helpers;
using System.Web.DynamicData;
using System.Runtime.CompilerServices;
using System.Web.Routing;
using System.Data.Entity.Infrastructure;

namespace uh365898_db.WebUI.Controllers
{
    
   [Authorize]//примененный без параметров, предоставит доступ к методам действия контроллера, если пользователь 
        //пройдет аутентификацию. Это означает, что если вы прошли аутентификацию, вы будете автоматически авторизированны для использования функций администрирования
    
       public class ControlsystemController : Controller

    {
       
        public  EFBContext cont = new EFBContext();
        private IProductRepository repository;
        public ControlsystemController(IProductRepository repo)
        {
            this.repository = repo;
        }





        public IQueryable<Order> Orders
        {
            get { return repository.Orders; }
        }


        public IQueryable<Categzer> Categzers
        {
            get { return repository.Categzers; }
        }
        public IQueryable<Categone> Categones
        {
            get { return repository.Categones; }
        }


        public IQueryable<Categtw> Categtws
        {
            get { return repository.Categtws; }
        }

        public IQueryable<Packing> Packings
        {
            get { return repository.Packings; }
        }

        public IQueryable<Producer> Producers
        {
            get { return repository.Producers; }
        }                  



        public ActionResult Goods(string sortGood )
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortGood) ? "Namedesc" : "";
            ViewBag.PriceSortParm = sortGood == "Price" ? "Pricedesc" : "Price";
            var catone = cont.Products.Include(p => p.Categone).Include(p => p.Producer).Include(p => p.Packing).Include(p => p.Categtw);
            switch (sortGood)
            {
                case "Namedesc":
                    catone = catone.OrderByDescending(p => p.Name);
                    break;
                case "Price":
                    catone = catone.OrderBy(p => p.Price);
                    break;
                case "Pricedesc":
                    catone = catone.OrderByDescending(p => p.Price);
                    break;
                default:
                    catone = catone.OrderBy(p => p.Name);
                    break;
            }
            ViewBag.Applyings = cont.Applyings.ToList();
            ViewBag.Propers = cont.Propers.ToList();
            ViewBag.Techcharacters = cont.Techcharacters.ToList();
            return View(catone.ToList());
        }



        public ViewResult  Allcategzer()
        {
            return View(repository.Categzers);
        }


        public ViewResult Allsubcategone()
        {
            return View(repository.Categones);
        }

        public ViewResult Allcategtw()
        {
            return View(repository.Categtws);
        }

        public ViewResult Allpacking()
        {
            return View(repository.Packings);
        }
        public ViewResult Allproper()
        {
            return View(repository.Propers);
        }
        public ViewResult Allapplying()
        {
            return View(repository.Applyings);
        }
        public ViewResult Alltechcharect()
        {
            return View(repository.Techcharacters);
        }

        public ViewResult AllFabricator()
        {
            return View(repository.Producers);
        }


        public ViewResult Feback()
        {
            return View(repository.Offers);
        }

        public ViewResult Guest()
        {
            return View(repository.Guestbooks);
        }

   public ViewResult Ordership()
   
       {
           var orders = repository.Orders.Include(m => m.Shipping);
           return View(orders.ToList());
       }


     public ViewResult Orderprod()
     {
         return View(repository.Orders);
     }


     
     public ActionResult Gallery()
     {
         return View("Gallery");
     }

     public ActionResult Filemanager()
     {
         return View("Filemanager");
     }
     public ActionResult Сalendar()
     {
         return View("Сalendar");
     }
     public ActionResult Tour()
     {
         return View("Tour");
     }

     public ViewResult Mainpage()
     {
         return View("Mainpage");
     }
    
 
public ViewResult Shippord() // все заказы
{
    //  var ship = cont.Shippings.Include(m => m.Orders).Single(m => m.Order == ship.ShippingID);

    return View(repository.Shippings);
}

public ViewResult Shipord(int sorder)// просмотр  заказа
      {
          ShippingsOrderViewModel viewModel = new ShippingsOrderViewModel
         {
             Orders = repository.Orders
                          .Where(p => sorder == null || p.OrderID == sorder)
                         .OrderBy(p => p.ShippingShippingID),
             CurrentOrder = sorder
         };
				    
        return View(viewModel);
} 



            /*
     public ActionResult Shippord(int? shippingID)
     {
     //    if (shippingID == null)
       //  {
      //       return HttpNotFound();
       //  }

         Shipping ship = repository.Shippings.FirstOrDefault(p => p.ShippingID == shippingID);
             if (ship != null)
             {
                 ship.Orders = repository.Orders.Where(m => m.ShippingShippingID == ship.ShippingID);// подгружаем все orders (товар+количество), связанные shipping         
                }
          return View(ship);
     }
      */

     public FileContentResult GetImage(int? offerId)
        {
            Offer ofget = repository.Offers.FirstOrDefault(p => p.OfferID == offerId);
            if (ofget != null)
                  {
                     return File(ofget.ImageData, ofget.ImageMimeType);
                   }
            else
                {
                   return null;
                 }
        }
  
  [HttpPost]
        public ActionResult DelOffer(int offerID)
        {
            Offer deletedOffer = repository.DeleteOffer(offerID);
            if (deletedOffer != null)
           {
               TempData["message"] = string.Format("Заявка'{0}' удалена", deletedOffer.Name);
            }
            return RedirectToAction("Feback");
          }

       
         [HttpPost]

         public ActionResult DelGB(int guestbookID)
         {
             Guestbook deletedGB = repository.DeleteGuestbook(guestbookID);
             if (deletedGB != null)
             {
                 TempData["message"] = string.Format("Отзыв'{0}' удален", deletedGB.Name);
             }
             return RedirectToAction("Guest");
         }  

        //Метод Create не визуализирует свое представление по умолчанию.
        //Вместо этого он указывает, что должно быть использовано представление Edit. 
        //То, что один метод действия использует представление, обычно связанное с другим представлением, 
        //является вполне приемлемым. В данном случае мы внедряем новый объект Product в качестве модели представления,
        //так что представление Edit заполняется пустыми полями.

         public ActionResult Detailgood(int productId)
         {
             Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

             if (product == null)
             {
                 return HttpNotFound();
             }
             return View(product);
         }


         [HttpGet]
       //  [ValidateInput(false)] // чтобы  не отбрасывало  хтмл или [AllowHtml] 
         public ViewResult Create() //  Формируем список категорий (one) для передачи в представление
         {
            ViewBag.ProducerID = new SelectList(cont.Producers, "ProducerID", "Name");
            ViewBag.CategoneID = new SelectList(cont.Categones, "CategoneID", "Name");
            ViewBag.CategtwID = new SelectList(cont.Categtws, "CategtwID", "Name");
            ViewBag.PackingID = new SelectList(cont.Packings, "PackingID", "Name");
            ViewBag.CategzerID = new SelectList(cont.Categzers, "CategzerID", "Name");

           // ViewBag.Techcharacters = new List<Techcharacter>();
           // ViewBag.Applyings = new List<Applying>();
         //   ViewBag.Propertys = new List<Property>();

            ViewBag.Techcharacters = cont.Techcharacters.ToList();
            ViewBag.Applyings = cont.Applyings.ToList();
            ViewBag.Propers = cont.Propers.ToList();


            return View("Create", new Product());
        }
            


         [HttpPost]
         [ValidateAntiForgeryToken]
      //   [ValidateInput(false)] // чтобы  не отбрасывало  хтмл или [AllowHtml] 
         public ActionResult Create(Product product, Categzer categzer, Categone categone, Categtw categtw, HttpPostedFileBase image, object sender, EventArgs e, int[] selectedApplyings, int[] selectedPropertys, int[] selectedTechcharacters) // - создание нового товара в админке
         {


             if (ModelState.IsValid)
             {

                          
               
                        if (image != null)
                         {
                 product.ImageMimeType = image.ContentType;
                 product.ImageData = new byte[image.ContentLength];
                 image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                             }

                 TempData["message"] = string.Format("Товар '{0}' сохранен", product.Name);

                 product.Applyings = new List<Applying>();
               if (selectedApplyings != null)
                {
                     foreach (var c in cont.Applyings) if (selectedApplyings.Contains(c.ApplyingID))

                    { product.Applyings.Add(c);}
                }

                  product.Propers = new List<Proper>();
                if (selectedPropertys!= null)
                {
                    foreach (var c in cont.Propers) if(selectedPropertys.Contains(c.ProperID))
                    {  product.Propers.Add(c); }
                }

                if (selectedTechcharacters != null)
                {
                    foreach (var c in cont.Techcharacters) if (selectedTechcharacters.Contains(c.TechcharacterID))
                    { product.Techcharacters.Add(c);
                   
                    }
                }

                ViewBag.Alldescription = product.Alldescription;
                ViewBag.Description = product.Description;
                ViewBag.ProducerID = new SelectList(cont.Producers, "ProducerID", "Name", product.ProducerID);
                ViewBag.CategoneID = new SelectList(cont.Categones, "CategoneID", "Name", product.CategoneID);
                ViewBag.CategtwID = new SelectList(cont.Categtws, "CategtwID", "Name", product.CategtwID);
                ViewBag.PackingID = new SelectList(cont.Packings, "PackingID", "Name", product.PackingID);
                ViewBag.CategzerID = new SelectList(cont.Categzers, "CategzerID", "Name", product.CategzerID);

                cont.Entry(product).State = EntityState.Modified;
                cont.Products.Add(product);
                cont.SaveChanges();
                TempData["message"] = string.Format("Товар '{0}' сохранен", product.Name);
               }

              
                ViewBag.Techcharacters = cont.Techcharacters.ToList();
                ViewBag.Applyings = cont.Applyings.ToList();
                ViewBag.Propers = cont.Propers.ToList();


                return RedirectToAction("Create");
            }
         


       



       
         public ActionResult Edit(int? productId,  int[] selectedProperty, int[] selectedTechcharacter)
        {

            if (productId == null)
            {
                return HttpNotFound();
            }


            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {

                ViewBag.ProducerID = new SelectList(cont.Producers, "ProducerID", "Name", product.ProducerID);
                ViewBag.CategoneID = new SelectList(cont.Categones, "CategoneID", "Name", product.CategoneID);
                ViewBag.CategtwID = new SelectList(cont.Categtws, "CategtwID", "Name", product.CategtwID);
                ViewBag.PackingID = new SelectList(cont.Packings, "PackingID", "Name", product.PackingID);
                ViewBag.CategzerID = new SelectList(cont.Categzers, "CategzerID", "Name", product.CategzerID);

                ViewBag.Techcharacters = cont.Techcharacters.ToList();
                ViewBag.Applyings = cont.Applyings.ToList();
                ViewBag.Propers = cont.Propers.ToList();

                List<Applying> applying = new List<Applying>();
                int[] selectedApplying = new int[] { 2 };
              
            }
             return View(product);
        }

         [HttpPost]
         public ActionResult Edit(Product product, HttpPostedFileBase image, int[] selectedApplying, int[] selectedProperty, int[] selectedTechcharacter)
         {
             if (ModelState.IsValid)
             {

                 Product dbEntry = cont.Products.Find(product.ProductID);
                 if (dbEntry != null)
                 {

                     dbEntry.Name = product.Name;
                     dbEntry.Description = product.Description;
                     dbEntry.Price = product.Price;
                     dbEntry.Category = product.Category;
                     if (image!= null  )
                     {
                         dbEntry.ImageMimeType = image.ContentType;
                         dbEntry.ImageData = new byte[image.ContentLength];
                         image.InputStream.Read(dbEntry.ImageData, 0, image.ContentLength);
                     }
                     dbEntry.CategzerID = product.CategzerID;
                     dbEntry.CategoneID = product.CategoneID;
                     dbEntry.CategtwID = product.CategtwID;
                     dbEntry.PackingID = product.PackingID;
                     dbEntry.Alldescription = product.Alldescription;
                     dbEntry.ImgUrl = product.ImgUrl;
                     dbEntry.ProdcodeID = product.ProdcodeID;
                     dbEntry.ProducerID = product.ProducerID;
                     dbEntry.Recomend = product.Recomend;

                   if (selectedApplying != null)
                     {
                 
                         dbEntry.Applyings.Clear();
                         foreach (var c in cont.Applyings.Where(co => selectedApplying.Contains(co.ApplyingID)))
                         {
                                                     
                             dbEntry.Applyings.Add(c);
                             
                         }
                     }


                     if (selectedProperty != null)
                     {
                         dbEntry.Propers.Clear();
                         foreach (var c in cont.Propers.Where(co => selectedProperty.Contains(co.ProperID)))
                         {
                             dbEntry.Propers.Add(c);
                         }
                     }

                     if (selectedTechcharacter != null)
                     {
                         dbEntry.Techcharacters.Clear();
                         foreach (var c in cont.Techcharacters.Where(co => selectedTechcharacter.Contains(co.TechcharacterID)))
                         {
                             dbEntry.Techcharacters.Add(c);
                         }
                     }

                     cont.Entry(dbEntry).State = EntityState.Modified;
                     cont.SaveChanges();
                     TempData["message"] = string.Format("Товар '{0}' сохранен", product.Name);

                     return RedirectToAction("Goods");
                 }
                 return RedirectToAction("Goods");
             }
             else
             {
                 // there is something wrong with the data values
                 return View(product);
             }
         }
    


        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Товар '{0}' удален", deletedProduct.Name);
            }
            return RedirectToAction("Goods");
          }



        [HttpGet]

        public ActionResult Addcategzer()
        {

            return View("Addcategzer", new Categzer());
        }

        [HttpPost]
        public ActionResult Addcategzer(Categzer categzer)
        {
            if (ModelState.IsValid)
            {

                cont.Categzers.Add(categzer);
                TempData["message"] = string.Format("Раздел товара  '{0}' сохранена", categzer.Name);
                cont.SaveChanges();
            }

            return RedirectToAction("Allcategzer");
        }

       [HttpGet]
        public ViewResult Edcategzer(int categzerId)
        {
            Categzer categzer = repository.Categzers.FirstOrDefault(p => p.CategzerID == categzerId);
            return View(categzer);
        }

        [HttpPost]
        public ActionResult Edcategzer(Categzer categzer, HttpPostedFileBase image)
        {
        if (ModelState.IsValid)
            {
             Categzer dbEntry = cont.Categzers.Find(categzer.CategzerID);
             if (dbEntry != null)
             {

                 dbEntry.Name = categzer.Name;
                 dbEntry.SectoneID = categzer.SectoneID;




                 cont.Entry(dbEntry).State = EntityState.Modified;
                 TempData["message"] = string.Format("Товар '{0}' сохранен", categzer.Name);
                 cont.SaveChanges();
             }
                return RedirectToAction("Allcategzer");

            }
            else
            {
                // there is something wrong with the data values
                return View(categzer);
            }
        }















       
       
       
       
       [HttpGet]

        public ActionResult Subcategone() 
        {
            
            return View("Subcategone", new Categone());
        }

       [HttpPost]
        public ActionResult Subcategone(Categone categone) 
         {
             if (ModelState.IsValid)
             {
                 
                 repository.SaveCategone(categone);
                 TempData["message"] = string.Format("Категория товара  '{0}' сохранена", categone.Name);
             }
               
                return RedirectToAction("Subcategone");
            }

       [HttpPost]
       public ActionResult  DelCateg(int categoneId)
       {
           Categone deletedCategone = repository.DeleteCategone(categoneId);
           if (deletedCategone != null)
           {
               TempData["message"] = string.Format("Категория '{0}' удалена", deletedCategone.Name);
           }
           return RedirectToAction("Allsubcategone");
       }



       [HttpGet]

       public ActionResult Fabricator() //  Формируем список категорий (one) для передачи в представление
       {

           return View("Fabricator", new Producer());
       }

       [HttpPost]
       public ActionResult Fabricator(Producer producer) //  Формируем список категорий (one) для передачи в представление
       {
           if (ModelState.IsValid)
           {

               repository.SaveProducer(producer);
               TempData["message"] = string.Format("Производитель товара  '{0}' сохранен", producer.Name);
           }
           
           return RedirectToAction("Fabricator");
       }

       [HttpPost]
       public ActionResult Delfabric(int producerID)
       {
           Producer deletedFabric = repository.DeleteProducer(producerID);
           if (deletedFabric != null)
           {
               TempData["message"] = string.Format("Производитель товара '{0}' удален", deletedFabric.Name);
           }
           return RedirectToAction("AllFabricator");
       }



       protected override void Dispose(bool disposing)
       {
           cont.Dispose();
           base.Dispose(disposing);
       }
      
       
       
       //         
       [HttpGet]

       public ActionResult Addtechcharect()
       {

           return View("Addtechcharect", new Techcharacter());
       }

       [HttpPost]
       public ActionResult Addtechcharect(Techcharacter techcharacter)
       {
           if (ModelState.IsValid)
           {

               cont.Techcharacters.Add(techcharacter);

               TempData["message"] = string.Format("Товар '{0}' сохранен", techcharacter.Name);
                 cont.SaveChanges();
           }

           return RedirectToAction("Addtechcharect");
       }

       [HttpPost]
       public ActionResult Deltechcharect(int techcharacterId)
       {
           Techcharacter deletedtechcharacter = cont.Techcharacters.Find(techcharacterId);
           if (deletedtechcharacter != null)
           {
               TempData["message"] = string.Format("Техническая характеристика '{0}' удалена", deletedtechcharacter.Name);
               cont.Techcharacters.Remove(deletedtechcharacter);
               cont.SaveChanges();
           }
           return RedirectToAction("Alltechcharect");
       }

       //

       [HttpGet]

       public ActionResult Addapplying()
       {

           return View("Addapplying", new Applying());
       }

       [HttpPost]
       public ActionResult Addapplying(Applying applying)
       {
           if (ModelState.IsValid)
           {

               cont.Applyings.Add(applying);
               cont.SaveChanges();
               TempData["message"] = string.Format("Применение товара '{0}' сохранено", applying.Name);
           }

           return RedirectToAction("Addapplying");
       }

       [HttpPost]
       public ActionResult DelApplying(int applyingId)
       {
           Applying deletedApplying = cont.Applyings.Find(applyingId);
           if (deletedApplying != null)
           {
               TempData["message"] = string.Format("Применение товара '{0}' удалено", deletedApplying.Name);
               cont.Applyings.Remove(deletedApplying);
               cont.SaveChanges();
           }
           return RedirectToAction("Allapplying");
       }



       //
       [HttpGet]

       public ActionResult Addproper()
       {

           return View("Addproper", new Proper());
       }

       [HttpPost]
       public ActionResult Addproper(Proper proper)
       {
           if (ModelState.IsValid)
           {

               cont.Propers.Add(proper);
               cont.SaveChanges();
               TempData["message"] = string.Format("Свойства товара  '{0}' сохранено", proper.Name);
           }

           return RedirectToAction("Addproper");
       }

       [HttpPost]
       public ActionResult DelProper(int properId)
       {
           Proper deletedProper = cont.Propers.Find(properId);
           if (deletedProper != null)
           {
               TempData["message"] = string.Format("Свойства товара '{0}' удалено", deletedProper.Name);
               cont.Propers.Remove(deletedProper);
               cont.SaveChanges();
           }
           return RedirectToAction("Allproper");
       }


       //
       [HttpGet]

       public ActionResult Subcategtw()
       {

           return View("Subcategtw", new Categtw());
       }

       [HttpPost]
       public ActionResult Subcategtw(Categtw categtw)
       {
           if (ModelState.IsValid)
           {

               cont.Categtws.Add(categtw);
               cont.SaveChanges();
               TempData["message"] = string.Format("Подкатегория товара  '{0}' сохранена", categtw.Name);
           }

           return RedirectToAction("Subcategtw");
       }

       [HttpPost]
       public ActionResult DelCategtw(int categtwId)
       {
           Categtw deletedCategtw = cont.Categtws.Find(categtwId);
           if (deletedCategtw != null)
           {
               TempData["message"] = string.Format("Подкатегория '{0}' удалена", deletedCategtw.Name);
               cont.Categtws.Remove(deletedCategtw);
               cont.SaveChanges();
           }
           return RedirectToAction("Allcategtw");
       }
//
       [HttpGet]

       public ActionResult Addpacking()
       {

           return View("Addpacking", new Packing());
       }

       [HttpPost]
       public ActionResult Addpacking(Packing packing)
       {
           if (ModelState.IsValid)
           {

               cont.Packings.Add(packing);
               cont.SaveChanges();
               TempData["message"] = string.Format("Упаковка товара  '{0}' сохранена", packing.Name);
           }

           return RedirectToAction("Addpacking");
       }

       [HttpPost]
       public ActionResult DelPacking(Product product, int packingId)
       {
           //Packing deletedPacking = cont.Packings.Find(packingId);
           var deletedPacking = cont.Packings.FirstOrDefault(c => c.PackingID == packingId);
           if (deletedPacking != null)
           {
               TempData["message"] = string.Format("Упаковка '{0}' удалена", deletedPacking.Name);
              // ((IObjectContextAdapter)cont).ObjectContext.LoadProperty(deletedPacking, u => u.Products);
             //  deletedPacking.Products.Clear();
            //   deletedPacking.Products.Remove(product);
             cont.Packings.Remove(deletedPacking);
               cont.SaveChanges();
           }
           return RedirectToAction("Allpacking");
       }


















        }
        
    }

// TempData нам идеально подходит. Данные ограничиваются сессией одного пользователя 
//(так что пользователи не видят другие TempData) и будут сохранены до тех пор, пока мы их не прочитаем. 
//Они понадобятся нам в представлении, визуализированном тем методом действия, к которому мы перенаправили пользователя.
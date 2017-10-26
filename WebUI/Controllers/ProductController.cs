using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using uh365898_db.WebUI.Models;
using uh365898_db.Domain.Concrete;
using uh365898_db.Domain.Abstract;
using uh365898_db.Domain.Entities;
using System.Data.Entity;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Web.Helpers;
using System.Web.DynamicData;
using System.Runtime.CompilerServices;
using System.Web.Routing;

namespace uh365898_db.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public EFBContext cont = new EFBContext();
        public int PageSize = 6;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public IQueryable<Categone> Categones
        {
            get { return repository.Categones; }
        }


        public IQueryable<Categtw> Categtws
        {
            get { return repository.Categtws; }
        }

        public ViewResult List(string category, int page = 1)
        {
            logger.Error("Просмотр главной странцы");
            try
            {
                ProductsListViewModel model = new ProductsListViewModel
                {
                    Products = repository.Products
                        // .Where(p => category == null || p.Categzer.Name == category)
                    .Where(p => p.Recomend== true)
                      .OrderBy(p => p.ProductID)
                      .Skip((page - 1) * PageSize)
                      .Take(PageSize),
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Categone.Name == category).Count()
                    },

                    CurrentCategory = category


                };

                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }




        public PartialViewResult Cartindex(Cart cart, string returnUrl, string returnedUrl)
        {
            return PartialView(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl,
                ReturnedUrl = returnedUrl
            });
        }


        public ActionResult Prepress(string fabrica, string categzer, string categ, string categtw, Product product)
        {
            var prepr = cont.Products.Include(p => p.Categzer).Include(p => p.Categone).Include(p => p.Categtw).Include(p => p.Producer).Where(p => categzer == null || p.Categzer.Name == "Пресс").OrderBy(p => p.ProductID);
            return View(prepr);
        }





        public ViewResult Shop(string fabrica, string categzer, string categ, string twocateg)


        {
            logger.Error("Просмотр каталога товара");

            try
            {
                ProductsListViewModel model = new ProductsListViewModel
                {
                    Products = repository.Products.Include(p => p.Categzer).Include(p => p.Categone).Include(p => p.Categtw).Include(p => p.Producer).Where(p => fabrica == null || p.Producer.Name == fabrica).Where(p => categ == null || p.Categone.Name == categ).Where(p => twocateg == null || p.Categtw.Name == twocateg).Where(p => categzer == null || p.Categzer.Name == categzer).OrderBy(p => p.ProductID),

                    CurrentFabrica = fabrica,
                    CurrentCatz = categzer,
                    CurrentCaton = categ,
                    CurrentCattw = twocateg,

                };


                return View(model);
            }
            catch (Exception)
            {
                return View();
            }
        }


        public PartialViewResult Prodcart(Product product)
        {
            return PartialView(product);
        }

        public PartialViewResult Breadcr( string categzer, string categ, string twocateg)
        {
            try
            {
                ProductsListViewModel model = new ProductsListViewModel
                {
                    Products  = repository.Products.Include(p => p.Categzer).Include(p => p.Categone).Include(p => p.Categtw).Include(p => p.Producer).Where(p => categ == null || p.Categone.Name == categ).Where(p => twocateg == null || p.Categtw.Name == twocateg).Where(p => categzer == null || p.Categzer.Name == categzer).OrderBy(p => p.ProductID),
               
      
       CurrentCatz = categzer,
       CurrentCaton =categ,
       CurrentCattw = twocateg,
                                
                };


                return PartialView(model);
            }
           catch (Exception)
            {
                return  PartialView();
            }
        
        
        }


        public PartialViewResult Fabrica(string fabr= null)
        {

            ViewBag.SelectedFabrica = fabr;
            IEnumerable<string> fabrica = repository.Products
              .Select(x => x.Producer.Name)
              .Distinct()
              .OrderBy(x => x), 
              CurrentFabrica = fabrica;
            
            return PartialView(fabrica);

        }

        public PartialViewResult Categ(string categone = null)
        {
            ViewBag.SelectedCategone = categone;

            IEnumerable<string> categ = repository.Products
              .Select(x => x.Categone.Name)
              .Distinct()
              .OrderBy(x => x);
            return PartialView(categ);
        }

        public PartialViewResult Cattw(string cattw = null)
        {
            ViewBag.SelectedCattw = cattw;

            IEnumerable<string> twocateg = repository.Products
              .Select(x => x.Categtw.Name)
              .Distinct()
              .OrderBy(x => x);
            return PartialView(twocateg);
        }


        public PartialViewResult Showgood(string fabrica, string categ, string twocateg, string categzer)
        {
            logger.Error("Просмотр товара №" );
            var catone = cont.Products.Include(p => p.Categzer)
                .Include(p => p.Categone)
                .Include(p => p.Categtw)
                .Include(p => p.Producer)
                .Where(p => fabrica == null || p.Producer.Name == fabrica)
                .Where(p => categ == null || p.Categone.Name == categ)
                .Where(p => twocateg == null || p.Categtw.Name == twocateg)
                .Where(p => categzer == null || p.Categzer.Name == categzer)
                .OrderBy(p => p.ProductID);
            return PartialView(catone);

        }


        // метод GetImage пытается найти товар, который соответствует указанному в параметре ID.
        //Он возвращает класс FileContentResult, когда мы хотим вернуть файл браузеру клиента, 
        //и экземпляры создаются с помощью метода File базового класса контроллера. 
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


        public ActionResult Store(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
          
            ViewBag.Techcharacters = cont.Techcharacters.ToList();
            ViewBag.Applyings = cont.Applyings.ToList();
            ViewBag.Propers = cont.Propers.ToList();

            return View(product);
        }




        public ViewResult Plates()
        {
            return View();
        }

        public ViewResult Paints(string fabrica, string categ)
        {
            var paint = cont.Products.Where(p => fabrica == null || p.Producer.Name == fabrica).Intersect(cont.Products.Where(p => p.Categone.Name.Contains("УФ-лаки")));
            return View(paint.ToList());
        }


        public ViewResult Cases_for_shaft()
        {
            return View();
        }
        public ViewResult Lac()
        {
            return View();
        }
        public ViewResult Poddekelnue_materials()
        {
            return View();

        }
        public ViewResult Chemistry()
        {
            return View();

        }

        public ViewResult Supporting_materials()// v yclovia pokupki
        {
            return View();

        }

        public ViewResult Printing_blanket()
        {
            return View();

        }

        public ViewResult New_items()
        {
            return View();

        }

    }
}


/*

   public ViewResult Shop(string sortShop, string fabrica, string categzer, string categ, string twocateg, Product product)
        {

            var catone = cont.Products.Include(p => p.Categzer).Include(p => p.Categone).Include(p => p.Categtw).Include(p => p.Producer).Where(p => fabrica == null || p.Producer.Name == fabrica).Where(p => categ == null || p.Categone.Name == categ).Where(p => twocateg == null || p.Categtw.Name == twocateg).Where(p => categzer == null || p.Categzer.Name == categzer).OrderBy(p => p.ProductID);
           ViewBag.NameSortParm = String.IsNullOrEmpty(sortShop) ? "Namedesc" : "";
            ViewBag.PriceSortParm = sortShop == "Price" ? "Pricedesc" : "Price"; 
            switch (sortShop)
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
            return View(catone);
        }
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using uh365898_db.Domain.Abstract;
using uh365898_db.Domain.Entities;

// EFProductRepository это наш класс хранилища. Он реализует интерфейс IProductRepository и использует экземпляр EFDbContext,
// чтобы извлекать данные из базы с помощью Entity Framework
namespace uh365898_db.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFBContext context = new EFBContext();
        private List<CartLine> lineCollection = new List<CartLine>();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        public IQueryable<Producer> Producers
        {
            get { return context.Producers; }
        }
        public IQueryable<Offer> Offers
        {
            get { return context.Offers; }
        }

        public IQueryable<Guestbook> Guestbooks
        {
            get { return context.Guestbooks; }
        }

        public IQueryable<Shipping> Shippings
        {
            get { return context.Shippings; }
        }

        public IQueryable<Order> Orders
        {
            get { return context.Orders; }
        }

        public IQueryable<Categtw> Categtws
        {
            get { return context.Categtws; }
        }
       
          public IEnumerable<Categtw> Categtw
         {
             get { return context.Categtws; }
         }

        
          public IQueryable<Categzer> Categzers
          {
              get { return context.Categzers; }
          }

          public IEnumerable<Categzer> Categzer
          {
              get { return context.Categzers; }
          }
        
        
        public IQueryable<Categone> Categones
         {
             get { return context.Categones; }
         }


         public IEnumerable<Categone> Categone
         {
             get { return context.Categones; }
         }

       


         public IQueryable<Packing> Packings
         {
             get { return context.Packings; }
         }
         public IQueryable<Packing> Packing
         {
             get { return context.Packings; }
         }



         public IQueryable<Techcharacter> Techcharacter
         {
             get { return context.Techcharacters; }
         }
         public IQueryable<Techcharacter> Techcharacters
         {
             get { return context.Techcharacters; }
         }


         public IQueryable<Applying> Applying
         {
             get { return context.Applyings; }
         }

         public IQueryable<Applying> Applyings
         {
             get { return context.Applyings; }
         }


         public IQueryable<Proper> Proper
         {
             get { return context.Propers; }
         }

         public IQueryable<Proper> Propers
         {
             get { return context.Propers; }
         }



      public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }


   

    public Shipping FindShipping(int shipID)

         {             
             Shipping ship = context.Shippings.Find(shipID);
              return ship;

            }

        public void SaveShipping(Shipping shipping)
         {
             if (shipping.ShippingID == 0)
            {
             /*   var shipp = new Shipping   {

                    ShippingID = shipping.ShippingID,
                    DateAdded = DateTime.Now,
                    Name = shipping.Name,
                    City = shipping.City,
                    State = shipping.State,
                    Zip = shipping.Zip,
                    Address = shipping.Address,
                    Phone = shipping.Phone,
                    Email = shipping.Email,
                    Message = shipping.Message,
                    
                };*/
                context.Shippings.Add(shipping);
           }
               context.SaveChanges();
        }

        public void SaveOffer(Offer offer)
        {
            if (offer.OfferID == 0)
            {
                context.Offers.Add(offer);//добавляет товар в хранилище, если ProductID равен 0
            }
            //  else //в противном случае она применяет изменения к существующей записи в базе данных.
            //   {
            //       FeedbackEntry dbFB = context.FeedbackEntrie.Find(FeedbackEn.Id);
            //     if (dbFB != null)
            //      {
            //         dbFB.DateAdded = DateTime.Now;
            //         dbFB.Name = FeedbackEn.Name;
            //         dbFB.Phone = FeedbackEn.Phone;
            //        dbFB.Email = FeedbackEn.Email;
            //        dbFB.Title = FeedbackEn.Title;
            //       dbFB.Description = FeedbackEn.Description;
            //       dbFB.ImageData = FeedbackEn.ImageData;
            //        dbFB.ImageMimeType = FeedbackEn.ImageMimeType;
            //   }
            //  }
            context.SaveChanges();
        }


        public void SaveGuestbook(Guestbook guestbook)
        {
            if (guestbook.GuestbookID == 0)
            {
                context.Guestbooks.Add(guestbook);//добавляет товар в хранилище, если ProductID равен 0
            }
            //  else //в противном случае она применяет изменения к существующей записи в базе данных.
            //   {
            //       FeedbackEntry dbFB = context.FeedbackEntrie.Find(FeedbackEn.Id);
            //     if (dbFB != null)
            //      {
            //         dbFB.DateAdded = DateTime.Now;
            //         dbFB.Name = FeedbackEn.Name;
            //         dbFB.Phone = FeedbackEn.Phone;
            //        dbFB.Email = FeedbackEn.Email;
            //        dbFB.Title = FeedbackEn.Title;
            //       dbFB.Description = FeedbackEn.Description;
            //       dbFB.ImageData = FeedbackEn.ImageData;
            //        dbFB.ImageMimeType = FeedbackEn.ImageMimeType;
            //   }
            //  }
            context.SaveChanges();
        }



        public void UpdateProduct(Product product)
        {
           

                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {

                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                     if (product.ImageData != null)
                    {
                        dbEntry.ImageData = product.ImageData;
                        dbEntry.ImageMimeType = product.ImageMimeType;
                    }
                     dbEntry.CategzerID = product.CategzerID;
                    dbEntry.CategoneID = product.CategoneID;
                     dbEntry.CategtwID = product.CategtwID;
                     dbEntry.PackingID = product.PackingID;
                    dbEntry.Alldescription = product.Alldescription;

                    dbEntry.ImgUrl = product.ImgUrl;
                    dbEntry.ProdcodeID = product.ProdcodeID;
                    dbEntry.ProducerID = product.ProducerID;

                  

                }
          
            context.SaveChanges();
        }



        // метод для сохранения результатов редактирования в админке
        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0 || String.IsNullOrEmpty(product.Category))
            {

                //  var dbEntry = context.Products.Find(categone.CategoneID);

              var prod = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = product.Category,
                    ImageData = product.ImageData,
                    ImageMimeType = product.ImageMimeType,
                    CategzerID = product.CategzerID,
                    CategoneID = product.CategoneID,
                    CategtwID = product.CategtwID,
                     PackingID = product.PackingID,
                     Alldescription = product.Alldescription,
                     ImgUrl = product.ImgUrl,
                    ProdcodeID = product.ProdcodeID,
                    ProducerID = product.ProducerID,
                    
                  
                }; 
                context.Products.Add(product);//добавляет товар в хранилище, если ProductID равен 0
            }
            context.SaveChanges();
        }

          


        public void SaveOrder(Cart cart, Shipping shipping, Order order)
        {
            if (order.OrderID == 0)
            {
                var cartItems = cart.Lines;
                foreach (var item in cartItems)
                {
                    item.Quantity = item.Quantity;

                    var Allpr = item.Product.Price * item.Quantity;
                    var ord = new Order
                    {

                        OrderID = order.OrderID,
                        DateAdded = DateTime.Now,
                        Prodnumb = item.Product.ProductID,
                        Prodname = item.Product.Name,
                        Total = item.Quantity,
                        Price = item.Product.Price,
                        Allprice = Allpr,
                        ShippingShippingID = shipping.ShippingID,
                    };

                    context.Orders.Add(ord);
                }
            }
            context.SaveChanges();
        }




       
        public void SaveCategone(Categone categone)
        {
            if (categone.CategoneID == 0)
            {
                context.Categones.Add(categone);//добавляет товар в хранилище, если ProductID равен 0
            }
            else //в противном случае она применяет изменения к существующей записи в базе данных.
            {
                Categone dbEntry = context.Categones.Find(categone.CategoneID);
                if (dbEntry != null)
                {
                                     
                    dbEntry.CategoneID = categone.CategoneID;
                    dbEntry.Name = categone.Name;
                    dbEntry.SectionID= categone.SectionID;

                }
            }
            context.SaveChanges();
        }



        public void SaveProducer(Producer producer)
        {
            if (producer.ProducerID == 0)
            {
                context.Producers.Add(producer);//добавляет товар в хранилище, если ProductID равен 0
            }
            else //в противном случае она применяет изменения к существующей записи в базе данных.
            {
                Producer dbEntry = context.Producers.Find(producer.ProducerID);
                if (dbEntry != null)
                {

                    dbEntry.ProducerID = producer.ProducerID;
                    dbEntry.Name = producer.Name;


                }
            }
            context.SaveChanges();
        }

        public Producer DeleteProducer(int producerID)
        {
            Producer dbEntry = context.Producers.Find(producerID);
            if (dbEntry != null)
            {
                context.Producers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }




        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }



        public Offer DeleteOffer(int offerID)
        {
            Offer dbOffer = context.Offers.Find(offerID);
            if (dbOffer != null)
            {
                context.Offers.Remove(dbOffer);
                context.SaveChanges();
            }
            return dbOffer;
        }



        public  Guestbook DeleteGuestbook(int guestbookID)
        {
            Guestbook dbGB = context.Guestbooks.Find(guestbookID);
            if (dbGB != null)
            {
                context.Guestbooks.Remove(dbGB);
                context.SaveChanges();
            }
            return dbGB;
        }


        public Categone DeleteCategone(int сategoneID)
        {
            Categone dbDC = context.Categones.Find(сategoneID);
            if (dbDC != null)
            {
                context.Categones.Remove(dbDC);
                context.SaveChanges();
            }
            return dbDC;
        }

        public object[] CategoneId { get; set; }
    }
}

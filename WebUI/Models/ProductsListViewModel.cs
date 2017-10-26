using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uh365898_db.Domain.Entities;


namespace uh365898_db.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public Categzer Categzer { get; set; }
        public Categone Categone { get; set; }
        public Categtw Categtw { get; set; }
        public Producer Producer { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentFabrica { get; set; }
        public string CurrentCatz { get; set; }
         public string CurrentCaton { get; set; }
         public string CurrentCattw { get; set; }
         public Product Product { get; set; }
         public Techcharacter Techcharacter { get; set; }
         public Applying Applying { get; set; }
         public Proper Proper { get; set; }
         public Cart cart { get; set; }

    }
}
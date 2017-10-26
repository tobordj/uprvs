using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uh365898_db.Domain.Entities;

namespace uh365898_db.WebUI.Models
{
    public class ShippingsOrderViewModel
    {
        public Shipping Shipping { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public Order Order { get; set; }
        public int CurrentOrder { get; set; }

    }
}
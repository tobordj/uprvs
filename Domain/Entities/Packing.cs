using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace uh365898_db.Domain.Entities
{
    public class Packing
    {
        [HiddenInput(DisplayValue = false)]
        public int PackingID { get; set; }

       [Required(ErrorMessage = "Пожалуйста, введите объем упаковки")]
       [Display(Name = "Название упаковки")]
        public string Name { get; set; }

       
       [Required(ErrorMessage = "Пожалуйста, введите единицу измерения")]
       [Display(Name = "Единица измерения(штуки,пачки, литры)")]
       public string Measure { get; set; }


        public virtual ICollection<Product> Products { get; set; }

        public Packing()
    {
        Products = new List<Product>();
    }

    }
}

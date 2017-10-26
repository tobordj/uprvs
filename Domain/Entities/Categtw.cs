using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace uh365898_db.Domain.Entities
{
    public class  Categtw 

    {
        [HiddenInput(DisplayValue = false)]
        public int? CategtwID { get; set; }

       [Required(ErrorMessage = "Пожалуйста, введите название подкатегории")]
       [Display(Name = "Название подкатегории")]
        public string Name { get; set; }

     

        public virtual ICollection<Product> Products { get; set; }

        public Categtw()
    {
        Products = new List<Product>();
    }

    }
}

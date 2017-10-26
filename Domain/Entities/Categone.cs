using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace uh365898_db.Domain.Entities
{
    public class Categone
    {
        [HiddenInput(DisplayValue = false)]
        public int CategoneID{ get; set; }

       [Required(ErrorMessage = "Пожалуйста, введите название подкатегории")]
       [Display(Name = "Название подкатегории")]
        public string Name { get; set; }

       [Required(ErrorMessage = "Пожалуйста, введите название раздела")]
       [Display(Name = "Название раздела (1,2,3)")]
       public int SectionID { get; set; }

       
        public virtual ICollection<Product> Products { get; set; }
        
        public Categone()
    {
        Products = new List<Product>();
    }

    }
}

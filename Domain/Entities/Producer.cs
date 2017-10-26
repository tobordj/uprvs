using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
   namespace uh365898_db.Domain.Entities
{
    public class Producer
    {
        [HiddenInput(DisplayValue = false)]
        public int ProducerID{ get; set; }

       [Required(ErrorMessage = "Пожалуйста, введите название производителя")]
       [Display(Name = "Название производителя")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}


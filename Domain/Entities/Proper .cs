using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace uh365898_db.Domain.Entities
{
    public class Proper
    {
        [HiddenInput(DisplayValue = false)]
        public int ProperID { get; set; }

        [DataType(DataType.MultilineText)]//позволяет указать, как значение должно отображаться и редактироваться. В данном случае мы выбрали опцию MultilineText. 
       [Required(ErrorMessage = "Пожалуйста, введите объем упаковки")]
       [Display(Name = "Свойства товара")]
        public string Name { get; set; }

      

        public virtual ICollection<Product> Products { get; set; }

        public Proper()
    {
        Products = new List<Product>();
    }

    }
}

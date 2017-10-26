using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace uh365898_db.Domain.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)] //что свойство нужно визуализировать как скрытый элемент формы, а атрибут
        public int ProductID { get; set; }

    [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        [Display(Name = "Название товара")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "Описание должно быть с {0} {2} знаков длиной.", MinimumLength = 26)]
        [DataType(DataType.MultilineText)]//позволяет указать, как значение должно отображаться и редактироваться. В данном случае мы выбрали опцию MultilineText. 
        [Required(ErrorMessage = "Пожалуйста, введите описание товара")]
        [Display(Name = "Описание товара")]
        [AllowHtml] 
        public string Description { get; set; }

        [Required]
      // [Range(0.00, double.MaxValue, ErrorMessage = "Пожалуйста, введите цену товара")]
      //  [DisplayFormat(DataFormatString = "{0:#,##0.000#}", ApplyFormatInEditMode = true)]
        [Display(Name = "Цена товара")]
        [Range(typeof(decimal), "1,0", "1000000000,6", ErrorMessage = "Наименьшая цена - 5 рублей, в качестве разделителя дробной и целой части используется запятая")]
        public decimal Price { get; set; }

     //  [Required(ErrorMessage = "Пожалуйста, введите категорию товара")]
       [Display(Name = "Категория товара")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }

       
       [HiddenInput(DisplayValue = false)]
         public string ImageMimeType { get; set; }




         public int CategzerID { get; set; }
         public int CategoneID { get; set; }

         public int? CategtwID { get; set; }// new



         public int PackingID { get; set; }// new

         // new
         [DataType(DataType.MultilineText)]//позволяет указать, как значение должно отображаться и редактироваться. В данном случае мы выбрали опцию MultilineText. 
         [Display(Name = "Полное описание товара")]
         [AllowHtml] 
         public string Alldescription { get; set; }

        // [Required(ErrorMessage = "Пожалуйста, введите URL ")]
         [Display(Name = "URL картинки")]
         [StringLength(1024)]
         public string ImgUrl { get; set; }

      //   [Required(AllowEmptyStrings = false, ErrorMessage = " ")]
       //  [RegularExpression("([0-100000000]+)")]
       //  [Range(0, 100000000, ErrorMessage = "Код 1С должен быть от 1 до 100000000 символов")]
         public int ProdcodeID { get; set; }

         public int ProducerID { get; set; }


       
         [ForeignKey("ProducerID")]
         public virtual Producer Producer { get; set; }

         [ForeignKey("CategzerID")]
         public virtual Categzer Categzer { get; set; }


        [ForeignKey("CategoneID")]
        public virtual Categone Categone { get; set; }

        
        [ForeignKey("CategtwID")]  // new
         public virtual Categtw Categtw { get; set; }
       
        [ForeignKey("PackingID")]  // new
         public virtual Packing Packing { get; set; }

        public virtual ICollection<Proper> Propers { get; set; } // new
        public virtual ICollection<Applying> Applyings { get; set; } // new
        public virtual ICollection<Techcharacter> Techcharacters { get; set; } // new

       
        public bool Recomend { get; set; }

        public Product()
    {
        Propers = new List<Proper>();
        Applyings = new List<Applying>();
        Techcharacters = new List<Techcharacter>();
    }
       
    }
}
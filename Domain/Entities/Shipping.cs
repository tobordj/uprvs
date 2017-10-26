using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using uh365898_db.Domain.Entities;
using uh365898_db.Domain.Concrete;
namespace uh365898_db.Domain.Entities
{


    
    public class Shipping
    {
       
        public int ShippingID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime DateAdded { get; set; }

       [Required(ErrorMessage = "Пожалуйста, введите Ваше Имя/Название организации")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя/Название организации должно быть от 2 до 50 символов")]
        [Display(Name = "Имя/Название организации:")]
        public string Name { get; set; }

      [Required(ErrorMessage = "Пожалуйста, введите Ваш город")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя/Название организации должно быть от 2 до 50 символов")]
        [Display(Name = "Город:")]
        public string City { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Ваш район города")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "РайонЫ должен быть от5 до 100 символов")]
        [Display(Name = "Район города:")]
        public string State { get; set; }

       [Required(ErrorMessage = "Пожалуйста, введите Ваш почтовый индекс")]
        [StringLength(6, MinimumLength = 3, ErrorMessage = "Почтовый индекс должен быть от 6 до 10 символов")]
        [Display(Name = "Почтовый код:")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Ваш адрес")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Адрес должен быть от 2 до 100 символов")]
        [Display(Name = "Адрес:")]
        public string Address { get; set; }

       [Required(ErrorMessage = "Пожалуйста, введите Ваш номер телефона")]
        [StringLength(13, MinimumLength = 6, ErrorMessage = "Телефон должен быть от 6 до 10 символов")]
        [Display(Name = "Телефон:")]
        public string Phone { get; set; }

           [Required(ErrorMessage = "Пожалуйста, введите Ваш Email")]
           [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный Email")]
           [StringLength(30, MinimumLength = 4, ErrorMessage = "Email должен быть от 4 до 30 символов")]
           [Display(Name = "Email:")]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
         [Required(ErrorMessage = "Пожалуйста, введите комментарии")]
           [StringLength(500, MinimumLength = 5, ErrorMessage = "Комментарии должны быть от 5 до 500 символов")]
           [Display(Name = "Комментарии", Prompt = "Комментарий")]
   
           public string Message { get; set; }

             

        public List<Order> Orders { get; set; }
        
    }


}


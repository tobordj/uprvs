using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace uh365898_db.Domain.Entities
{
    public class Offer
    {
        [HiddenInput(DisplayValue = false)] //что свойство нужно визуализировать как скрытый элемент формы, а атрибут
        public int OfferID { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Ваше Имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        [Display(Name = "Имя:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Ваш телефон")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Телефон должен быть от 6 до 10 символов")]
        [Display(Name = "Телефон:")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Пожалуйста, введите Ваш Email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Адрес электронной почты:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите тему сообщения")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Тема сообщения должна быть от 2 до 50 символов")]
        [Display(Name = "Тема сообщения")]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
          
        [Required(ErrorMessage = "Пожалуйста, введите Ваше сообщение")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Сообщение должно быть от 2 до 500 символов")]
        [Display(Name = "Сообщение", Prompt = "Ваше сообщение")]

        public string Description { get; set; }


        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }



    }

}
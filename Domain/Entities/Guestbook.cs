using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace uh365898_db.Domain.Entities
{
    public class Guestbook
    {
        [HiddenInput(DisplayValue = false)] 
        public int GuestbookID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите Ваше Имя")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Имя должно быть от 2 до 50 символов")]
        [Display(Name = "Имя:")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Пожалуйста, введите сообщение")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Сообщение должно быть от 2 до 500 символов")]
        [Display(Name = "Сообщение", Prompt = "Ваше сообщение")]
        public string Message { get; set; }

        public DateTime DateAdded { get; set; }
    }
}

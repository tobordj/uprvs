using System.ComponentModel.DataAnnotations;
namespace uh365898_db.WebUI.Models
{
    public class LoginViewModel
    {
        
        [Required(ErrorMessage = "Пожалуйста, введите логин")]
        public string UserName { get; set; }

       
        [Required(ErrorMessage = "Пожалуйста, введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}     //Этот класс содержит свойства для имени пользователя и пароля, а также использует атрибуты DataAnnotation, 
//чтобы указать, что требуются значения обоих свойств. Кроме того, мы используем атрибут DataType, чтобы сообщить
//MVC Framework, как мы хотим отображать редактор свойства Password
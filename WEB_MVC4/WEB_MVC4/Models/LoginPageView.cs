using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB_MVC4.Models
{
    public partial class LoginPageView
    {
        [DisplayName("Логин или e-mail")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Пожалуйста введите ваш e-mail или логин")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пожалуйста введите ваш пароль")]
        public string Password { get; set; }
    }
}
using System;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WEB_MVC4.Models
{
    public partial class RegistrationPageView
    {
        [DisplayName("Логин")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Пожалуйста введите ваш логин")]
        public string Login { get; set; }

        [DisplayName("Имя")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Пожалуйста введите ваше имя")]
        public string Name { get; set; }

        [DisplayName("Фамилия")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Пожалуйста введите вашу фамилию")]
        public string LastName { get; set; }

        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пожалуйста введите ваш пароль")]
        public string Password { get; set; }

        [DisplayName("Повторите пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Пожалуйста введите ваш пароль ещё раз")]
        public string RepeatPassword { get; set; }

        [DisplayName("Адрес e-mail")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Пожалуйста введите ваш e-mail")]
        public string Email { get; set; }

        [DisplayName("Телефон")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string Validate()
        {
            string Target = null;
            try
            {
                if (Login.Length < 7 || Login.Length > 20 || !Login.Any(char.IsDigit) || !Login.Any(char.IsUpper) || !Login.Any(char.IsLower) || !Login.All(char.IsLetterOrDigit))
                    Target = "Логин должен быть не менее 7 и не более 20 символов и содержать в себе цифры и буквы большого и маленького регистров";
                else if (Password.Length < 7 || Password.Length > 20 || !Password.Any(char.IsDigit) || !Password.Any(char.IsUpper) || !Password.Any(char.IsLower) || !Password.All(char.IsLetterOrDigit))
                    Target = "Пароль должен быть не менее 7 и не более 20 символов и содержать в себе цифры и буквы большого и маленького регистров";
                else if (!Password.Equals(RepeatPassword))
                    Target = "Пароли не совпадают";
                else if (!Name.All(char.IsLetter))
                    Target = "Имя может содержать только буквы";
                else if (!LastName.All(char.IsLetter))
                    Target = "Фамилия может содержать только буквы";
            }
            catch(Exception e)
            {
                Target = "Что-то не указано";
            }
            return Target;
        }
    }
}
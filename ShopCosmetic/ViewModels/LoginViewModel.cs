using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Имя пользователя")]
        public string UserName { get; set; }

      
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Длина пароля не может быть меньше 6 символов, пароль должен содержать как минимум один цифровой и один не алфавитно-цифровой символ, а также как минимум один алфавитный символ должен быть в верхнем регистре.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }


    }
}

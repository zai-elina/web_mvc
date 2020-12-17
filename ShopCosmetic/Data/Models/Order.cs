using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCosmetic.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        
        [Display(Name = "Введите имя")]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина имени не более 10 символов")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина имени не более 15 символов")]
        public string SurName { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина имени не более 15 символов")]
        public string Address { get; set; }

        [Display(Name = "Введите номер телефона")]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Вы не правильно ввели номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Введите почту")]
        [StringLength(20)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
                    ErrorMessage = "Вы не правильно ввели почту")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public List<OrderDetail> orderDetails { get;set;}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGamesWebApplication.Models
{
    [Table("customers")]
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Display(Name = "Номер покупця")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер телефону")]
        public long? PhoneNumber { get; set; }
        [Display(Name = "Адреса")]
        public string? Address { get; set; }
        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string? FirstName { get; set; }
        [Display(Name = "По-батькові")]
        public string? MiddleName { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Прізвище")]
        public string? LastName { get; set; }

        public string? Name { get => $"{FirstName} {MiddleName} {LastName}"; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

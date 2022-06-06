using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardGamesWebApplication.Models
{
    public partial class State
    {
        public State()
        {
            Orders = new HashSet<Order>();
        }
        [Required(ErrorMessage = "Поле не повинно бути порожнім.")]
        [Display(Name = "Статус")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім.")]
        [Display(Name = "Статус")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім.")]
        [Display(Name = "Замовлення")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}

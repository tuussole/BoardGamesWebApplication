using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardGamesWebApplication.Models
{
    public partial class Order
    {
        public Order()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        [Display(Name = "Покупець")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int CustomerId { get; set; }
        [Display(Name = "Дата та час")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public DateTime DateTime { get; set; }
        [Display(Name = "Статус")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int StateId { get; set; }
        [Display(Name = "Покупець")]
        public virtual Customer? Customer { get; set; }
        [Display(Name = "Статус")]
        public virtual State? State { get; set; }
        [Display(Name = "Товари")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public virtual ICollection<Item> Items { get; set; }

        public string Name { get => $"Замовлення #{Id}"; }
    }
}

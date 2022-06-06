using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGamesWebApplication.Models
{
    [Table("items")]
    public partial class Item
    {
        [Range(0, 100)]
        public int Id { get; set; }
        [Display(Name = "Кількість")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int Quantity { get; set; }
        [Display(Name = "Гра")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int GameId { get; set; }
        [Display(Name = "Замовлення")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int OrderId { get; set; }
        [Display(Name = "Гра")]
        public virtual Game? Game { get; set; }
        [Display(Name = "Замовлення")]
        public virtual Order? Order { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardGamesWebApplication.Models
{
    public partial class TypeGame
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім.")]
        [Display(Name = "Тип")]
        public int TypeId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім.")]
        [Display(Name = "Гра")]
        public int GameId { get; set; }
        [Display(Name = "Гра")]
        public virtual Game? Game { get; set; }
        [Display(Name = "Тип")]
        public virtual Type? Type { get; set; }
    }
}

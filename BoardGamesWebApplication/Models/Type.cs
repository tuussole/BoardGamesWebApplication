using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BoardGamesWebApplication.Models
{
    public partial class Type
    {
        public Type()
        {
            TypeGames = new HashSet<TypeGame>();
        }
        [Display(Name = "Тип ігри")]
        public int Id { get; set; }
        [Display(Name = "Опис")]
        public string? Description { get; set; }
        [Display(Name = "Тип ігри")]
        public string Name { get; set; }

        public virtual ICollection<TypeGame> TypeGames { get; set; }
    }
}

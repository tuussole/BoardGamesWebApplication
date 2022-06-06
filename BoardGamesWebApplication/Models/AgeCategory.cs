using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGamesWebApplication.Models
{
    [Table("age_categories")]
    public partial class AgeCategory
    {
        public AgeCategory()
        {
            Games = new HashSet<Game>();
        }

        [Range(0, 100)]
        [Display(Name = "Номер вікової категорії")]
        public int Id { get; set; }
        [Display(Name = "Вікова категорія")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Name { get; set; }
        [Range(0, 100)] 
        [Display(Name = "Мінімальний вік")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public int From { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}

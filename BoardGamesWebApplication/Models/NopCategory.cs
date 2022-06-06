using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGamesWebApplication.Models
{
    [Table("nop_categories")]
    public partial class NopCategory
    {
        public NopCategory()
        {
            Games = new HashSet<Game>();
        }
       
        public int Id { get; set; }
        [Display(Name = "Від")]
        [Range(1, 100)]
        public int? From { get; set; }
        [Display(Name = "До")]
        [Range(0, 100)]
        public int? To { get; set; }
        [Display(Name = "Категорія кількості гравців")]
        [Required(ErrorMessage = "Повинно бути не порожнім")]
        public string? Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}

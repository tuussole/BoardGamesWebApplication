using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGamesWebApplication.Models
{
    [Table("groups")]
    public partial class Group
    {
        public Group()
        {
            Games = new HashSet<Game>();
        }
        [Range(0, 100)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім.")]
        [DataType(DataType.Text)]
        [Display(Name = "Група")]
        public string Name { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}

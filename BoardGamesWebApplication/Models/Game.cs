using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGamesWebApplication.Models
{
    [Table("games")]
    public partial class Game
    {
        public Game()
        {
            Items = new HashSet<Item>();
            TypeGames = new HashSet<TypeGame>();
        }
        [Range(0, 100)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім.")]
        [DataType(DataType.Text)]
        [Display(Name = "Гра")] 
        public string Name { get; set; }
        [Display(Name = "Опис")] 
        public string? Description { get; set; }
        [Display(Name = "Категорія кількості гравців")]
        [ForeignKey("NOPCategory")]
       
        public int Nopid { get; set; }
        [Range(1, 100)]
        [Display(Name = "Вартість")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім.")]
        public decimal Price { get; set; }
        [Display(Name = "Залишок")]
        [Range(0, 100)]
        public int? LeftQuantity { get; set; }
        [Display(Name = "Вікова категорія")]
        [ForeignKey("AgeCategory")]
        
        public int AgeId { get; set; }
        [Display(Name = "Група")]
       
        public int GroupId { get; set; }
        [Display(Name = "Вікова категорія")]
        public virtual AgeCategory? Age { get; set; }
        [Display(Name = "Група")]
        public virtual Group? Group { get; set; }
        [Display(Name = "Категорія кількості гравців")]
        public virtual NopCategory? Nop { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<TypeGame> TypeGames { get; set; }
    }
}

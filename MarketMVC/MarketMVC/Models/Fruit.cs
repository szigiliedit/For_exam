using System.ComponentModel.DataAnnotations;

namespace MarketMVC.Models
{
    public class Fruit
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Price { get; set; }
        [Required]
        [Range(1, 2)]
        public byte Quality { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RadoreProje.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Labels { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
        public string HoverImg { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public Rating Rating { get; set; }
        public ICollection<ColorOption> ColorOptions { get; set; }
    }
}
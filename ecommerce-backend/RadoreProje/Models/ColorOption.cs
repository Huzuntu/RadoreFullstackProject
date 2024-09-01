using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RadoreProje.Models
{
    public class ColorOption
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Color { get; set; } = string.Empty; 

        public string? Img { get; set; } 

        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!; 
    }
}
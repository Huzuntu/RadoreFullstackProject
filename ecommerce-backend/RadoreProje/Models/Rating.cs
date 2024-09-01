using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadoreProje.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }
        public double Rate { get; set; }
        public int Count { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}